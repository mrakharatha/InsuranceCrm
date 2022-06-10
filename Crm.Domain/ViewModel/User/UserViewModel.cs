using System.ComponentModel.DataAnnotations;

namespace Crm.Domain.ViewModel.User;

public class UserViewModel
{
    public int UserId { get; set; }

    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string Name { get; set; }



    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string UserName { get; set; }


    [Display(Name = "کلمه عبور")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [DataType(DataType.Password)]

    public string? Password { get; set; }

    public bool IsActive { get; set; }

    public List<int>? UserRoles { get; set; }
}