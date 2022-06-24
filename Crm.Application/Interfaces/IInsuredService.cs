using Crm.Domain.ViewModel.DataTable;
using Crm.Domain.ViewModel.Insured;

namespace Crm.Application.Interfaces;

public interface IInsuredService
{
    Task<DtResult<InsuredViewModel>> GetData(DtParameters dtParameters);

}