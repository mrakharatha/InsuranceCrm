using System.ComponentModel.DataAnnotations;
using Crm.Domain.Models.Permissions;

namespace Crm.Domain.Models.User;

public class UserRole
{
    [Key]
    public int UR_Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }


    #region Relations

    public  User User { get; set; }
    public  Role Role { get; set; }

    #endregion
}