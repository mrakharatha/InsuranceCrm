using Crm.Domain.Models.Permissions;

namespace Crm.Application.Interfaces;

public interface IPermissionService
{
    List<Role> GetRoles();
    List<Permission> GetAllPermission();
    void AddRole(Role role);
    void AddRolePermission(int roleId, List<int> permissions);
    List<int> PermissionsRole(int roleId);
    Role? GetRoleById(int roleId);
    void UpdateRole(Role role);
    void UpdateRolePermission(int roleId, List<int> permissions);
    void DeleteRolePermission(int roleId);
    bool CheckPermission(int permissionId, int userId);
    List<int> GetUserRolesByUserId(int userId);
    List<int> GetRolePermissionByPermissionId(int permissionId);
    void AddUserRole(int userId, List<int> selectedRoles);
    void UpdateUserRole(int userId, List<int> selectedRoles);
    void DeleteUserRole(int userId);
    bool CheckDelete(int roleId);
    void DeleteRole(int roleId);
}