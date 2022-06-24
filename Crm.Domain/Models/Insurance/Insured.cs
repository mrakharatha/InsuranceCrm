using System.ComponentModel.DataAnnotations;

namespace Crm.Domain.Models.Insurance;

public class Insured
{
    [Key]
    public int InsuredId { get; set; }
    public int UserId { get; set; }


    [Display(Name = "مشتری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public int? CustomerId { get; set; }

    [Display(Name = "اقساط")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public int? InstallmentId { get; set; }

    [Display(Name = "روش پرداخت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public int? PaymentMethodId { get; set; }

    [Display(Name = "مدت بیمه نامه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public int? TermInsuranceId { get; set; }

    [Display(Name = "بیمه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public int? InsuranceId { get; set; }


    [Display(Name = "مبلغ حق بیمه سال اول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [Range(0, UInt64.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
    public ulong FirstYearPremiumAmount { get; set; }

    [Display(Name = "تاریخ شروع قسط")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public DateTime InstallmentStartDate { get; set; }


    [Display(Name = "مبلغ هر قسط")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [Range(0, UInt64.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
    public ulong AmountPerInstallment { get; set; }


    [Display(Name = "سرمایه فوت سال اول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [Range(0, UInt64.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
    public ulong CapitalDeathFirstYear { get; set; }

    [Display(Name = "تاریخ شروع بیمه نامه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public DateTime StartDateOfInsurancePolicy { get; set; }

    [Display(Name = "تاریخ پایان بیمه نامه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public DateTime EndDateOfInsurancePolicy { get; set; }


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
    public Installment.Installment? Installment { get; set; }
    public Customer.Customer? Customer { get; set; }
    public PaymentMethod.PaymentMethod? PaymentMethod { get; set; }
    public TermInsurance? TermInsurance { get; set; }
    public Insurance? Insurance { get; set; }
    public List<InsuredInstallment>? InsuredInstallments { get; set; }
    #endregion
}