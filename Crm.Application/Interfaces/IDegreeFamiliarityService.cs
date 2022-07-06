using Crm.Domain.Models;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Interfaces;

public interface IDegreeFamiliarityService
{
    List<DegreeFamiliarity> GetAllDegreeFamiliarity();
    DegreeFamiliarity? GetDegreeFamiliarityById(int degreeFamiliarityId);
    void AddDegreeFamiliarity(DegreeFamiliarity degreeFamiliarity);
    void UpdateDegreeFamiliarity(DegreeFamiliarity degreeFamiliarity);
    void DeleteDegreeFamiliarity(int degreeFamiliarityId);
    bool CheckCodeDegreeFamiliarity(int degreeFamiliarityId, int code);
    List<SelectListItem> GetDegreeFamiliarities();
}