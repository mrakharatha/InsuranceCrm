using System.ComponentModel.DataAnnotations;
using Crm.Domain.Models.Insurance;

namespace Crm.Domain.Models.User;

public class User
{
    [Key]
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
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string Password { get; set; }

    [Display(Name = "وضعیت")]
    public bool IsActive { get; set; }


    [Display(Name = "تاریخ ثبت")]
    public DateTime CreateDate { get; set; } = DateTime.Now;
    [Display(Name = "تاریخ ویرایش")]
    public DateTime? UpdateDate { get; set; }
    [Display(Name = "تاریخ حذف")]
    public DateTime? DeleteDate { get; set; }


    #region Relations

    public  List<UserRole>? UserRoles { get; set; }
    public List<MaritalStatus.MaritalStatus>? MaritalStatus { get; set; }
    public List<Customer.Customer>? Customers { get; set; }
    public List<Insurance.Insurance>? Insurances { get; set; }
    public List<PaymentMethod.PaymentMethod>? PaymentMethods { get; set; }
    public List<Installment.Installment>? Installments { get; set; }
    public List<TermInsurance>? TermInsurances { get; set; }
    public List<Insured>? Insureds { get; set; }
    #endregion

}