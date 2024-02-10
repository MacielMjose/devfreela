namespace DevFreela.Core.Entities;

public class UserSkill : BaseEntity
{
    public UserSkill(int idUsuario, int idSkill)
    {
        IdUsuario = idUsuario;
        IdSkill = idSkill;
    }

    public int IdUsuario { get; private set; }
    public int IdSkill { get; private set; }
}