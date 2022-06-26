using System.ComponentModel.DataAnnotations;

namespace Crm.Domain.Models.Insurance;

public class Introduced
{
    [Key]
    public int IntroducedId { get; set; }
    public int UserId { get; set; }


    [Display(Name = "درجه آشنائیت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public int? DegreeFamiliarityId { get; set; }


    [Display(Name = "نسبت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public int? RatioId { get; set; }



    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string FullName { get; set; }


    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = " {0} فرمت نامناسب دارد")]
    public string PhoneNumber { get; set; }


    [Display(Name = "توضیحات")]
    [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string? Description { get; set; }

    [Display(Name = "تاریخ ثبت")]
    public DateTime CreateDate { get; set; } = DateTime.Now;
    [Display(Name = "تاریخ ویرایش")]
    public DateTime? UpdateDate { get; set; }
    [Display(Name = "تاریخ حذف")]
    public DateTime? DeleteDate { get; set; }


    #region Relations

    public User.User? User { get; set; }
    public DegreeFamiliarity? DegreeFamiliarity { get; set; }
    public Ratio? Ratio { get; set; }

    #endregion
}