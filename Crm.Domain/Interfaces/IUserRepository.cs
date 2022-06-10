using Crm.Domain.Models.User;
using Crm.Domain.ViewModel.Account;
using Crm.Domain.ViewModel.User;

namespace Crm.Domain.Interfaces;

public interface IUserRepository
{
    List<User> GetAllUsers();
    bool IsExistUserName(int userId,string userName);
    void AddUser(User user);
    UserViewModel? GetUserViewModel(int userId);
    void UpdateUser(User user);
    User? GetUserById(int userId);
    User? LoginUser(LoginViewModel login);
}