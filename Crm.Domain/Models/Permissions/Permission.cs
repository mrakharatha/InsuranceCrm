using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Domain.Models.Permissions;

public class Permission
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PermissionId { get; set; }


    [Display(Name = "عنوان نقش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string Title { get; set; }

    public int? ParentId { get; set; }

    #region Relations

    [ForeignKey("ParentId")]
    public  List<Permission>? Permissions { get; set; }
    public List<RolePermission>? RolePermission { get; set; }

    #endregion
}