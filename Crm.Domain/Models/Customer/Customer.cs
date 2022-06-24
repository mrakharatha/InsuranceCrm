using System.ComponentModel.DataAnnotations;
using Crm.Domain.Models.Area;
using Crm.Domain.Models.Insurance;

namespace Crm.Domain.Models.Customer;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    public int UserId { get; set; }

    [Display(Name = "استان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public int? ProvinceId { get; set; }


    [Display(Name = "شهرستان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public int? TownshipId { get; set; }


    [Display(Name = "وضعیت تاهل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public int? MaritalStatusId { get; set; }

    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string FullName { get; set; }  
    
    
    [Display(Name = "کد ملی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [RegularExpression(@"^([0-9]){10}$", ErrorMessage = "{0} فرمت نامناسب دارد")]
    public string NationalCode { get; set; }



    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = " {0} فرمت نامناسب دارد")]
    public string PhoneNumber { get; set; }


    [Display(Name = "محل سکونت")]
    public string? Address { get; set; }
    
    
    [Display(Name = "توضیحات (دلیل انتخاب نمایندگی بنده )")]
    public string? Description { get; set; }

    [Display(Name = "تاریخ تولد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "تاریخ سالگرد ازدواج")]
    public DateTime? DateOfMarriageAnniversary { get; set; }

    [Display(Name = "تاریخ تولد همسر")]
    public DateTime? DateOfBirthSpouse { get; set; }


    [Display(Name = "تاریخ ثبت")]
    public DateTime CreateDate { get; set; } = DateTime.Now;
    [Display(Name = "تاریخ ویرایش")]
    public DateTime? UpdateDate { get; set; }
    [Display(Name = "تاریخ حذف")]
    public DateTime? DeleteDate { get; set; }



    #region Relations

    public User.User? User { get; set; }

    public MaritalStatus.MaritalStatus? MaritalStatus { get; set; }
    public Province? Province { get; set; }
    public Township? Township { get; set; }
    public List<Insured>? Insureds { get; set; }

    #endregion

}