namespace DevFreela.Application.ViewModels;

public class UserViewModel
{
    public UserViewModel(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
    }

    public int Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
}