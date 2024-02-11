using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class UserService : IUserService
{
    private DevFreelaDbContext _devFreelaDbContext;

    public UserService(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public UserViewModel? GetById(int id)
    {
        var user = _devFreelaDbContext.Users.SingleOrDefault(u => u.Id == id);

        if (user is null)
            return null;

        var userViewModel = new UserViewModel(user.FullName, user.Email);
        
        return userViewModel;
    }

    public int Create(NewUserInputModel newUserInputModel)
    {
        var addUser = new User(newUserInputModel.UserName, newUserInputModel.Email, newUserInputModel.DataNascimento);
        _devFreelaDbContext.Users.Add(addUser);

        return addUser.Id;
    }
}