using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public ProjectService(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public List<ProjectViewModel> GetAll(string query)
    {
        var projects = _devFreelaDbContext.Projects.ToList();

        var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

        return projectsViewModel;
    }

    public ProjectDetailsViewModel? GetById(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);

        if (project == null)
            return null;
        
        var projectDetailViewModel = new ProjectDetailsViewModel(
            project.Id,
            project.Title,
            project.Description,
            project.TotalCost,
            project.StartedAt,
            project.FinishedAt);

        return projectDetailViewModel;
    }

    public int Create(NewProjectInputModel newProjectInputModel)
    {
        var project = new Project(newProjectInputModel.Title, newProjectInputModel.Description,
            newProjectInputModel.IdClient, newProjectInputModel.IdFreelancer, newProjectInputModel.TotalCost);

        _devFreelaDbContext.Projects.Add(project);

        return project.Id;
    }

    public void Update(UpdatProjectInputModel updatProjectInputModel)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == updatProjectInputModel.Id);
        project?.Update(updatProjectInputModel.Title, updatProjectInputModel.Description, updatProjectInputModel.TotalCost);
    }

    public void Delete(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project?.Cancel();
    }

    public void CreateComment(CreateCommentInputModel createCommentInputModel)
    {
        var comment = new ProjectComment(createCommentInputModel.Content, createCommentInputModel.IdProject,
            createCommentInputModel.IdUser);

        _devFreelaDbContext.Comments.Add(comment);
    }

    public void Start(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project?.Start();
    }

    public void Finish(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project?.Finish();
    }
}