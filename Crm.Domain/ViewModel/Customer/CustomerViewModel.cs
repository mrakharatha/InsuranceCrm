using System.ComponentModel.DataAnnotations;
using Crm.Domain.ViewModel.DataTable;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Domain.ViewModel.Customer;

public class CustomerViewModel
{
    [Display(Name = "ردیف")]
    public int Row { get; set; }
    public int CustomerId { get; set; }
    [Display(Name = "نام و نام خانوادگی")]
    public string FullName { get; set; }
    [Display(Name = "کد ملی")]
    public string NationalCode { get; set; }
    [Display(Name = "شماره موبایل")]
    public string PhoneNumber { get; set; }
    [Display(Name = "تاریخ تولد")]
    public string DateOfBirth { get; set; }
    [Display(Name = "تاریخ ثبت")]
    public string CreateDate { get; set; }
    [Display(Name = "عملیات")]
    public string Operation { get; set; }
}

public class AddCustomerViewModel
{

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

    [Remote("IsNationalCodeExist", "Customer", ErrorMessage = "{0} تکراری می باشد")]
    public string NationalCode { get; set; }

    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = " {0} فرمت نامناسب دارد")]
    [Remote("IsPhoneNumberExist", "Customer", ErrorMessage = "{0} تکراری می باشد")]

    public string PhoneNumber { get; set; }

    [Display(Name = "محل سکونت")]
    public string? Address { get; set; }

    [Display(Name = "توضیحات (دلیل انتخاب نمایندگی بنده )")]
    public string? Description { get; set; }

    [Display(Name = "تاریخ تولد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public string DateOfBirth { get; set; }

    [Display(Name = "تاریخ سالگرد ازدواج")]
    public string? DateOfMarriageAnniversary { get; set; }

    [Display(Name = "تاریخ تولد همسر")]
    public string? DateOfBirthSpouse { get; set; }
}



public class EditCustomerViewModel
{
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

    [Remote("IsNationalCodeExist", "Customer", AdditionalFields = nameof(CustomerId), ErrorMessage = "{0} تکراری می باشد")]
    public string NationalCode { get; set; }

    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = " {0} فرمت نامناسب دارد")]
    [Remote("IsPhoneNumberExist", "Customer", AdditionalFields = nameof(CustomerId), ErrorMessage = "{0} تکراری می باشد")]

    public string PhoneNumber { get; set; }

    [Display(Name = "محل سکونت")]
    public string? Address { get; set; }

    [Display(Name = "توضیحات (دلیل انتخاب نمایندگی بنده )")]
    public string? Description { get; set; }

    [Display(Name = "تاریخ تولد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    public string DateOfBirth { get; set; }

    [Display(Name = "تاریخ سالگرد ازدواج")]
    public string? DateOfMarriageAnniversary { get; set; }

    [Display(Name = "تاریخ تولد همسر")]
    public string? DateOfBirthSpouse { get; set; }
}