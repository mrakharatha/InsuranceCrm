using Crm.Application.Interfaces;
using Crm.Application.Utilities;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.User;
using Crm.Domain.ViewModel.Account;
using Crm.Domain.ViewModel.User;

namespace Crm.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public bool IsExistUserName(int userId,string userName)
    {
        return _userRepository.IsExistUserName(userId,userName);
    }

    public void AddUser(User user)
    {
        user.Password = SecurityHelper.GetSha256Hash(user.Password);
        _userRepository.AddUser(user);
    }

    public UserViewModel? GetUserViewModel(int userId)
    {
        return _userRepository.GetUserViewModel(userId);
    }

    public void UpdateUser(UserViewModel user)
    {
        var userUpdate = GetUserById(user.UserId);
        if (userUpdate == null)
            return;


        userUpdate.Name = user.Name;
        userUpdate.IsActive = user.IsActive;
        if (user.Password.HasValue())
            userUpdate.Password = SecurityHelper.GetSha256Hash(user.Password);

        UpdateUser(userUpdate);
    }

    public void UpdateUser(User user)
    {
        user.UpdateDate = DateTime.Now;
        _userRepository.UpdateUser(user);
    }

    public User? GetUserById(int userId)
    {
        return _userRepository.GetUserById(userId);
    }

    public bool DeleteUser(int userId)
    {
        var user = GetUserById(userId);
        if (user == null)
            return false;

        user.DeleteDate = DateTime.Now;

        UpdateUser(user);

        return true;
    }

    public User? LoginUser(LoginViewModel login)
    {
        login.Password = SecurityHelper.GetSha256Hash(login.Password);
        login.UserName = login.UserName.Trim();
        return _userRepository.LoginUser(login);
    }
}