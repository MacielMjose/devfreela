using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext
{
    public DevFreelaDbContext()
    {
        Projects = new List<Project>()
        {
            new Project("Meu primeiro ASPNETCORE 1", "Minha descrição de Projeto 1", 1, 1, 1000),
            new Project("Meu primeiro ASPNETCORE 2", "Minha descrição de Projeto 2", 1, 1, 2000),
            new Project("Meu primeiro ASPNETCORE 3", "Minha descrição de Projeto 3", 1, 1, 3000),
        };
        Users = new List<User>()
        {
            new User("Luis Felipe", "luisdev@luisdev.com.br", new DateTime(1992, 1, 1)),
            new User("Robert C Martin", "robert@luisdev.com.br", new DateTime(1950, 1, 1)),
            new User("Anderson", "anderson@luisdev.com.br", new DateTime(1980, 1, 1)),
        };
        Skills = new List<Skill>()
        {
            new Skill(".NET Core"),
            new Skill("C#"),
            new Skill("SQL"),
        };
        Comments = new List<ProjectComment>();
    }

    public List<Project> Projects { get; set; }
    public List<Skill> Skills { get; set; }
    public List<User> Users { get; set; }
    public List<ProjectComment> Comments { get; set; }
}