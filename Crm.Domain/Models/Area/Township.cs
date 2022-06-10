using System.ComponentModel.DataAnnotations;

namespace Crm.Domain.Models.Area;

public class Township
{
    public int TownshipId { get; set; }
    public int ProvinceId { get; set; }
    [Display(Name = "نام شهرستان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string TownshipName { get; set; }
    #region Relations

    public Province? Province { get; set; }
    public List<Customer.Customer>? Customers { get; set; }

    #endregion
}