using Crm.Domain.Models.Permissions;
using Crm.Domain.Models.User;

namespace Crm.Domain.Interfaces;

public interface IPermissionRepository
{
    List<Role> GetRoles();
    List<Permission> GetAllPermission();
    void AddRole(Role role);
    void AddRolePermission(List<RolePermission> rolePermissions);
    void UpdateRolePermission(List<RolePermission> rolePermissions);
    List<int> GetRolePermission(int roleId);
    Role? GetRoleById(int roleId);
    void UpdateRole(Role role);
    void DeleteRolePermission(int roleId);
  
    bool CheckDelete(int roleId);

    void AddUserRole(List<UserRole> userRoles);
    void DeleteUserRole(int userId);
    List<int> GetUserRolesByUserId(int userId);
    List<int> GetRolePermissionByPermissionId(int permissionId);
}