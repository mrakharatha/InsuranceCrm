using Crm.Domain.Models.Insurance;
using Crm.Domain.ViewModel.DataTable;
using Crm.Domain.ViewModel.Insured;

namespace Crm.Application.Interfaces;

public interface IInsuredService
{
    Task<DtResult<InsuredViewModel>> GetData(DtParameters dtParameters);

    void AddInsured(AddInsuredViewModel model);
    void AddInsured(Insured  insured);

    void AddInsuredInstallment(int insuredId,int installmentId,DateTime installmentStartDate);
    void AddInsuredInstallmentRange(List<InsuredInstallment> insuredInstallments);
}