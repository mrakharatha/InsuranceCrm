using Crm.Domain.Models.Insurance;
using Crm.Domain.ViewModel.DataTable;
using Crm.Domain.ViewModel.Insured;

namespace Crm.Domain.Interfaces;

public interface IInsuredRepository
{
    Task<DtResult<InsuredViewModel>> GetData(DtParameters dtParameters);
    void AddInsured(Insured insured);
    void AddInsuredInstallmentRange(List<InsuredInstallment> insuredInstallments);
    Insured? GetInsuredById(int insuredId);
    void UpdateInsured(Insured insured);
    void DeleteInsuredInstallment(int insuredId);
    List<InsuredInstallmentsViewModel> GetInsuredInstallmentsByInsuredId(int insuredId);
}