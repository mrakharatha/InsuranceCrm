using Crm.Domain.Models;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Interfaces;

public interface IInsuranceService
{
    List<Insurance> GetAllInsurance();
    Insurance? GetInsuranceById(int insuranceId);
    void AddInsurance(Insurance insurance);
    void UpdateInsurance(Insurance insurance);
    void DeleteInsurance(int insuranceId);
    bool CheckCodeInsurance(int insuranceId, int code);
    List<SelectListItem> GetInsurance();
}