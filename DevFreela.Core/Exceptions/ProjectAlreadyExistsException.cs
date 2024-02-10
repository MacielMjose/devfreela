namespace DevFreela.Core.Exceptions;

public class ProjectAlreadyExistsException : Exception
{
    public ProjectAlreadyExistsException()
    : base("Project is already in Started status")
    {
        
    }
}