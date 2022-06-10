using Crm.Domain.Models.User;
using Crm.Domain.ViewModel.Account;
using Crm.Domain.ViewModel.User;

namespace Crm.Application.Interfaces;

public interface IUserService
{
    List<User> GetAllUsers();
    bool IsExistUserName(int userId,string userName);
    void AddUser(User user);

    UserViewModel? GetUserViewModel(int userId);

    void UpdateUser(UserViewModel user);
    void UpdateUser(User user);
    User? GetUserById(int userId);
    bool DeleteUser(int userId);
    User? LoginUser(LoginViewModel login);
}