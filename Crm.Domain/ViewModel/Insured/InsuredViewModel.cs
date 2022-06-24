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
}
