using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public SkillService(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public List<SkillViewModel> GetAll()
    {
        var skills = _devFreelaDbContext.Skills.ToList();

        var skillsViewModel = skills
            .Select(s => new SkillViewModel(s.Id, s.Description))
            .ToList();

        return skillsViewModel;
    }

    public SkillViewModel? GetById(int id)
    {
        var skill = _devFreelaDbContext.Skills
            .SingleOrDefault(s => s.Id == id);

        if (skill is null)
            return null;
        
        var skillViewModel = new SkillViewModel(skill.Id, skill.Description);

        return skillViewModel;
    }
}