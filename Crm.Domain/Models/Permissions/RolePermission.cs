using System.ComponentModel.DataAnnotations;

namespace Crm.Domain.Models.Permissions
{
  public  class RolePermission
    {
        [Key]
        public int RolePermissionId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }



        #region Relations

        public  Role? Role { get; set; }
        public  Permission? Permission { get; set; }

        #endregion
    }
}
