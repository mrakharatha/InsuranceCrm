using Crm.Domain.Interfaces;
using Crm.Domain.ViewModel.DataTable;
using Crm.Domain.ViewModel.Insured;
using Crm.Infra.Data.Context;

namespace Crm.Infra.Data.Repository;

public class InsuredRepository: IInsuredRepository
{
    private readonly ApplicationContext _context;

    public InsuredRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Task<DtResult<InsuredViewModel>> GetData(DtParameters dtParameters)
    {
        throw new NotImplementedException();
    }
}