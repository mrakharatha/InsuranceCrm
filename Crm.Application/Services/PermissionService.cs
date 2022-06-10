using Crm.Application.Interfaces;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.Permissions;
using Crm.Domain.Models.User;

namespace Crm.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;

    public PermissionService(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public List<Role> GetRoles()
    {
        return _permissionRepository.GetRoles();
    }

    public List<Permission> GetAllPermission()
    {
        return _permissionRepository.GetAllPermission();
    }

    public void AddRole(Role role)
    {
        _permissionRepository.AddRole(role);
    }

    public void AddRolePermission(int roleId, List<int> permissions)
    {
        var rolePermissions = new List<RolePermission>();


        foreach (var permission in permissions)
        {
            rolePermissions.Add(new RolePermission()
            {
                RoleId = roleId,
                PermissionId = permission
            });
        }

        _permissionRepository.AddRolePermission(rolePermissions);
    }

    public List<int> PermissionsRole(int roleId)
    {
        return _permissionRepository.GetRolePermission(roleId);
    }

    public Role? GetRoleById(int roleId)
    {
        return _permissionRepository.GetRoleById(roleId);
    }

    public void UpdateRole(Role role)
    {
        role.UpdateDate = DateTime.MaxValue;
        _permissionRepository.UpdateRole(role);
    }

    public void UpdateRolePermission(int roleId, List<int> permissions)
    {
        DeleteRolePermission(roleId);
        AddRolePermission(roleId, permissions);
    }

    public void DeleteRolePermission(int roleId)
    {
        _permissionRepository.DeleteRolePermission(roleId);
    }

    public bool CheckPermission(int permissionId, int userId)
    {
        if (userId == 1)
            return true;

        var userRoles = GetUserRolesByUserId(userId);

        if (!userRoles.Any())
            return false;

        var rolePermission = GetRolePermissionByPermissionId(permissionId);

        return rolePermission.Any(p => userRoles.Contains(p));
    }

    public List<int> GetUserRolesByUserId(int userId)
    {
        return _permissionRepository.GetUserRolesByUserId(userId);
    }

    public List<int> GetRolePermissionByPermissionId(int permissionId)
    {
        return _permissionRepository.GetRolePermissionByPermissionId(permissionId);
    }

    public void AddUserRole(int userId, List<int> selectedRoles)
    {
        var userRoles = new List<UserRole>();

        foreach (var role in selectedRoles)
        {
            userRoles.Add(new UserRole()
            {
                RoleId = role,
                UserId = userId
            });
        }
        _permissionRepository.AddUserRole(userRoles);

    }

    public void UpdateUserRole(int userId, List<int> selectedRoles)
    {
        DeleteUserRole(userId);
        AddUserRole(userId, selectedRoles);
    }

    public void DeleteUserRole(int userId)
    {
        _permissionRepository.DeleteUserRole(userId);
    }

    public bool CheckDelete(int roleId)
    {
        return _permissionRepository.CheckDelete(roleId);
    }

    public void DeleteRole(int roleId)
    {
        Role? role = GetRoleById(roleId);

        if (role == null)
            return;

        role.DeleteDate = DateTime.Now;
        UpdateRole(role);
    }

}