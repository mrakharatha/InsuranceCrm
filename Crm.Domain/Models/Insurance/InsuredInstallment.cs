using System.ComponentModel.DataAnnotations;

namespace Crm.Domain.Models.Insurance;

public class InsuredInstallment
{
    [Key]
    public int InsuredInstallmentId { get; set; }
    public int InsuredId { get; set; }
    public DateTime DateInstallment { get; set; }

    #region Relations

    public Insured? Insured { get; set; }

    #endregion
}