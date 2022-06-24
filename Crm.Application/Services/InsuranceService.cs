using Crm.Application.Interfaces;
using Crm.Domain.Interfaces;
using Crm.Domain.Models;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Services;

public class InsuranceService: IInsuranceService
{
    private readonly IInsuranceRepository _insuranceRepository;

    public InsuranceService(IInsuranceRepository insuranceRepository)
    {
        _insuranceRepository = insuranceRepository;
    }


    public List<Insurance> GetAllInsurance()
    {
        return _insuranceRepository.GetAllInsurance();
    }

    public Insurance? GetInsuranceById(int insuranceId)
    {
        return _insuranceRepository.GetInsuranceById(insuranceId);
    }

    public void AddInsurance(Insurance insurance)
    {
        _insuranceRepository.AddInsurance(insurance);
    }

    public void UpdateInsurance(Insurance insurance)
    {
        insurance.UpdateDate = DateTime.Now;
        _insuranceRepository.UpdateInsurance(insurance);
    }

    public void DeleteInsurance(int insuranceId)
    {
        var insurance = GetInsuranceById(insuranceId);

        if (insurance == null)
            return;

        insurance.DeleteDate = DateTime.Now;
        UpdateInsurance(insurance);
    }

    public bool CheckCodeInsurance(int insuranceId, int code)
    {
        return _insuranceRepository.CheckCodeInsurance(insuranceId, code);
    }

    public List<SelectListItem> GetInsurance()
    {
        var result = _insuranceRepository.GetInsurance();

        var items = new List<SelectListItem>()
        {
            new SelectListItem(){Value = null,Text = "لطفا انتخاب کنید"}
        };

        items.AddRange(result);
        return items;
    }
}