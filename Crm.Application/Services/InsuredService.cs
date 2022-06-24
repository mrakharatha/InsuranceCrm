using Crm.Application.Interfaces;
using Crm.Domain.Interfaces;
using Crm.Domain.ViewModel.DataTable;
using Crm.Domain.ViewModel.Insured;

namespace Crm.Application.Services;

public class InsuredService: IInsuredService
{
    private readonly IInsuredRepository _insuredRepository;

    public InsuredService(IInsuredRepository insuredRepository)
    {
        _insuredRepository = insuredRepository;
    }

    public async Task<DtResult<InsuredViewModel>> GetData(DtParameters dtParameters)
    {
        var result = _insuredRepository.GetData(dtParameters);
        return await result;
    }
}