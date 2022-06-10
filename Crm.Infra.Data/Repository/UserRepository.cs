using Crm.Domain.Interfaces;
using Crm.Domain.Models.User;
using Crm.Domain.ViewModel.Account;
using Crm.Domain.ViewModel.User;
using Crm.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infra.Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }
    public User? LoginUser(LoginViewModel login)
    {
        return _context.Users.SingleOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);
    }

    public List<User> GetAllUsers()
    {
        return _context.Users
            .Where(x => x.UserId != 1)
            .OrderByDescending(x => x.UserId).ToList();
    }

    public bool IsExistUserName(int userId, string userName)
    {
        if (userId == 0)
            return _context.Users.Any(x => x.UserName == userName);

        return _context.Users.Any(x => x.UserName == userName && x.UserId != userId);
    }

    public void AddUser(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
    }


    public UserViewModel? GetUserViewModel(int userId)
    {
        return _context.Users
            .Include(x => x.UserRoles)
            .Select(u => new UserViewModel()
            {
                UserName = u.UserName,
                Name = u.Name,
                IsActive = u.IsActive,
                UserId = u.UserId,
                UserRoles = u.UserRoles.Select(r => r.RoleId).ToList(),

            })
            .SingleOrDefault(u => u.UserId == userId);

    }

    public void UpdateUser(User user)
    {

        _context.Update(user);
        _context.SaveChanges();
    }

    public User? GetUserById(int userId)
    {
        return _context.Users.Find(userId);
    }
}