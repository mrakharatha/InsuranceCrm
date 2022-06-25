using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Domain.ViewModel.Insured
{
    public class InsuredViewModel
    {
        [Display(Name = "ردیف")]
        public int Row { get; set; }
        public int InsuredId { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "بیمه")]
        public string Insurance { get; set; }

        [Display(Name = "روش پرداخت")]
        public string PaymentMethod { get; set; }

        [Display(Name = "تاریخ شروع بیمه نامه")]
        public string StartDateOfInsurancePolicy { get; set; }

        [Display(Name = "تاریخ پایان بیمه نامه")]
        public string EndDateOfInsurancePolicy { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public string CreateDate { get; set; }
        [Display(Name = "عملیات")]
        public string Operation { get; set; }
    }

    public class AddInsuredViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "مشتری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? CustomerId { get; set; }

        [Display(Name = "مدت بیمه نامه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? TermInsuranceId { get; set; }

        [Display(Name = "بیمه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? InsuranceId { get; set; }


        [Display(Name = "اقساط")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? InstallmentId { get; set; }

        [Display(Name = "روش پرداخت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? PaymentMethodId { get; set; }



        [Display(Name = "مبلغ حق بیمه سال اول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [Range(0, UInt64.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public ulong FirstYearPremiumAmount { get; set; }
        public string NumberFirstYearPremium { get; set; }


        [Display(Name = "مبلغ هر قسط")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [Range(0, UInt64.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public ulong AmountPerInstallment { get; set; }
        public string NumberPerInstallment { get; set; }

        [Display(Name = "سرمایه فوت سال اول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [Range(0, UInt64.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public ulong CapitalDeathFirstYear { get; set; }
        public string NumberCapitalDeathFirstYear { get; set; }


        [Display(Name = "تاریخ شروع قسط")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public string InstallmentStartDate { get; set; }

        [Display(Name = "تاریخ شروع بیمه نامه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public string StartDateOfInsurancePolicy { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
    }
    public class EditInsuredViewModel
    {
        public int InsuredId { get; set; }
        public int UserId { get; set; }

        [Display(Name = "مشتری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? CustomerId { get; set; }

        [Display(Name = "مدت بیمه نامه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? TermInsuranceId { get; set; }

        [Display(Name = "بیمه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? InsuranceId { get; set; }


        [Display(Name = "اقساط")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? InstallmentId { get; set; }

        [Display(Name = "روش پرداخت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public int? PaymentMethodId { get; set; }



        [Display(Name = "مبلغ حق بیمه سال اول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [Range(0, UInt64.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public ulong FirstYearPremiumAmount { get; set; }
        public string NumberFirstYearPremium { get; set; }


        [Display(Name = "مبلغ هر قسط")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [Range(0, UInt64.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public ulong AmountPerInstallment { get; set; }
        public string NumberPerInstallment { get; set; }

        [Display(Name = "سرمایه فوت سال اول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [Range(0, UInt64.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public ulong CapitalDeathFirstYear { get; set; }
        public string NumberCapitalDeathFirstYear { get; set; }


        [Display(Name = "تاریخ شروع قسط")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public string InstallmentStartDate { get; set; }

        [Display(Name = "تاریخ شروع بیمه نامه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public string StartDateOfInsurancePolicy { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
    }

    public class InsuredInstallmentsViewModel
    {
        [Display(Name = "مبلغ هر قسط")]
        public ulong AmountPerInstallment { get; set; }
        [Display(Name = "تاریخ هر قسط")]
        public DateTime DateInstallment { get; set; }

    }

}
