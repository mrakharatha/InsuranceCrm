using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Domain.Interfaces;

public interface ITermInsuranceRepository
{
    List<TermInsurance> GetAllTermInsurance();
    TermInsurance? GetTermInsuranceById(int termInsuranceId);
    void AddTermInsurance(TermInsurance termInsurance);
    void UpdateTermInsurance(TermInsurance termInsurance);
    bool CheckCodeTermInsurance(int termInsuranceId, int code);
    List<SelectListItem> GetTermInsurance();

}