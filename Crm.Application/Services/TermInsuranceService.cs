using Crm.Application.Interfaces;
using Crm.Application.Utilities;
using Crm.Domain.Enum.TypeSystem;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Services;

public class TermInsuranceService: ITermInsuranceService
{
    private readonly ITermInsuranceRepository _termInsuranceRepository;

    public TermInsuranceService(ITermInsuranceRepository termInsuranceRepository)
    {
        _termInsuranceRepository = termInsuranceRepository;
    }

    public List<TermInsurance> GetAllTermInsurance()
    {
        return _termInsuranceRepository.GetAllTermInsurance();
    }

    public TermInsurance? GetTermInsuranceById(int termInsuranceId)
    {
        return _termInsuranceRepository.GetTermInsuranceById(termInsuranceId);
    }

    public void AddTermInsurance(TermInsurance termInsurance)
    {
        _termInsuranceRepository.AddTermInsurance(termInsurance);
    }

    public void UpdateTermInsurance(TermInsurance termInsurance)
    {
        termInsurance.UpdateDate = DateTime.Now;
        _termInsuranceRepository.UpdateTermInsurance(termInsurance);
    }

    public void DeleteTermInsurance(int termInsuranceId)
    {
        var termInsurance = GetTermInsuranceById(termInsuranceId);

        if (termInsurance == null)
            return;


        termInsurance.DeleteDate = DateTime.Now;
        UpdateTermInsurance(termInsurance);
    }

    public bool CheckCodeTermInsurance(int termInsuranceId, int code)
    {
        return _termInsuranceRepository.CheckCodeTermInsurance(termInsuranceId, code);
    }

    public List<SelectListItem> GetTypeSystem()
    {
        var list = new List<SelectListItem> { new SelectListItem() { Value = null, Text = "لطفا انتخاب کنید" } };
        list.AddRange(from TypeSystem val in Enum.GetValues(typeof(TypeSystem)) select new SelectListItem() { Value = val.ToString(), Text = val.ToDisplay() });
        return list;
    }

    public List<SelectListItem> GetTermInsurance()
    {
        return _termInsuranceRepository.GetTermInsurance();
    }
}