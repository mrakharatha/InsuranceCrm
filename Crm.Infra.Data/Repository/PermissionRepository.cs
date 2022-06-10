using Crm.Domain.Interfaces;
using Crm.Domain.Models.Permissions;
using Crm.Domain.Models.User;
using Crm.Infra.Data.Context;

namespace Crm.Infra.Data.Repository;

public class PermissionRepository: IPermissionRepository
{
    private readonly ApplicationContext _context;

    public PermissionRepository(ApplicationContext context)
    {
        _context = context;
    }

    public List<Role> GetRoles()
    {
        return _context.Roles
            .OrderByDescending(x => x.RoleId)
            .ToList();
    }

    public List<Permission> GetAllPermission()
    {
        return _context.Permission.OrderBy(x => x.PermissionId).ToList();
    }

    public void AddRole(Role role)
    {
        _context.Add(role);
        _context.SaveChanges();
    }

    public void AddRolePermission(List<RolePermission> rolePermissions)
    {
        _context.AddRange(rolePermissions);
        _context.SaveChanges();
    }

    public List<int> GetRolePermission(int roleId)
    {
        return _context.RolePermissions
            .Where(r => r.RoleId == roleId)
            .Select(r => r.PermissionId)
            .ToList();
    }

    public Role? GetRoleById(int roleId)
    {
        return _context.Roles.Find(roleId);
    }

    public void UpdateRole(Role role)
    {
        _context.Update(role);
        _context.SaveChanges();
    }

    public void  UpdateRolePermission(List<RolePermission> rolePermissions)
    {
        _context.UpdateRange(rolePermissions);
        _context.SaveChanges();
    }

    public void DeleteRolePermission(int roleId)
    {
        _context.RolePermissions.Where(p => p.RoleId == roleId)
            .ToList().ForEach(p => _context.Remove(p));

        _context.SaveChanges();
    }

    public bool CheckDelete(int roleId)
    {
        return _context.UserRoles.Any(c => c.RoleId == roleId);
    }

    public void AddUserRole(List<UserRole> userRoles)
    {
        _context.AddRange(userRoles);
        _context.SaveChanges();
    }

    public void DeleteUserRole(int userId)
    {
        _context.UserRoles.Where(p => p.UserId == userId)
            .ToList().ForEach(p => _context.Remove(p));

        _context.SaveChanges();
    }

    public List<int> GetUserRolesByUserId(int userId)
    {
        return _context.UserRoles
            .Where(u => u.UserId == userId)
            .Select(r => r.RoleId).ToList();
    }

    public List<int> GetRolePermissionByPermissionId(int permissionId)
    {
        return _context.RolePermissions
            .Where(p => p.PermissionId == permissionId)
            .Select(p => p.RoleId)
            .ToList();
    }
}