using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Interfaces;

public interface ITermInsuranceService
{
    List<TermInsurance> GetAllTermInsurance();
    TermInsurance? GetTermInsuranceById(int termInsuranceId);
    void AddTermInsurance(TermInsurance termInsurance);
    void UpdateTermInsurance(TermInsurance termInsurance);
    void DeleteTermInsurance(int termInsuranceId);
    bool CheckCodeTermInsurance(int termInsuranceId, int code);
    List<SelectListItem> GetTypeSystem();
    List<SelectListItem> GetTermInsurance();
}