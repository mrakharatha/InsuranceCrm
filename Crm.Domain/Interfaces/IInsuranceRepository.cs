using Crm.Domain.Models;
using Crm.Domain.Models.Insurance;
using Crm.Domain.Models.PaymentMethod;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Domain.Interfaces;

public interface IInsuranceRepository
{
    List<Insurance> GetAllInsurance();
    Insurance? GetInsuranceById(int insuranceId);
    void AddInsurance(Insurance insurance);
    void UpdateInsurance(Insurance insurance);
    bool CheckCodeInsurance(int insuranceId, int code);
    List<SelectListItem> GetInsurance();
}