namespace DevFreela.Core.Entities;

public class User : BaseEntity
{
    public User(string fullName, string email, DateTime dataNascimento)
    {
        FullName = fullName;
        Email = email;
        DataNascimento = dataNascimento;
        CreatedAt = DateTime.Now;
        Active = true;
        Skills = new List<UserSkill>();
        OwnedProjects = new List<Project>();
        FreelanceProjects = new List<Project>();
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<UserSkill> Skills { get; private set; }
    public bool Active { get; private set; }

    public List<Project> OwnedProjects { get; private set; }
    public List<Project> FreelanceProjects { get; private set; }
}