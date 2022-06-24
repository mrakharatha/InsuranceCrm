using System.ComponentModel.DataAnnotations;
using Crm.Domain.Models.Insurance;

namespace Crm.Domain.Models.PaymentMethod;

public class PaymentMethod
{
    [Key]
    public int PaymentMethodId { get; set; }


    public int UserId { get; set; }


    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string Title { get; set; }


    [Display(Name = "کد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [Range(0, Int32.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
    public int? Code { get; set; }



    [Display(Name = "تاریخ ثبت")]
    public DateTime CreateDate { get; set; } = DateTime.Now;
    [Display(Name = "تاریخ ویرایش")]
    public DateTime? UpdateDate { get; set; }
    [Display(Name = "تاریخ حذف")]
    public DateTime? DeleteDate { get; set; }


    #region Relations

    public User.User? User { get; set; }
    public List<Insured>? Insureds { get; set; }

    #endregion
}