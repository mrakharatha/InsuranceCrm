using Crm.Domain.ViewModel.DataTable;
using Crm.Domain.ViewModel.Insured;

namespace Crm.Domain.Interfaces;

public interface IInsuredRepository
{
    Task<DtResult<InsuredViewModel>> GetData(DtParameters dtParameters);

}