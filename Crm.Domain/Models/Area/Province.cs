using System.ComponentModel.DataAnnotations;

namespace Crm.Domain.Models.Area;

public class Province
{
    [Key]
    public int ProvinceId { get; set; }

    [Display(Name = "نام استان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string ProvinceName { get; set; }

    #region Relations

    public List<Township>? Townships { get; set; }
    public List<Customer.Customer>? Customers { get; set; }
    #endregion
}