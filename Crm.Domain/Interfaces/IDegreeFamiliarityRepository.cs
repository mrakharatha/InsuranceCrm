using Crm.Domain.Models;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Domain.Interfaces;

public interface IDegreeFamiliarityRepository
{
    List<DegreeFamiliarity> GetAllDegreeFamiliarity();
    DegreeFamiliarity? GetDegreeFamiliarityById(int degreeFamiliarityId);
    void AddDegreeFamiliarity(DegreeFamiliarity degreeFamiliarity);
    void UpdateDegreeFamiliarity(DegreeFamiliarity degreeFamiliarity);
    bool CheckCodeDegreeFamiliarity(int degreeFamiliarityId, int code);
    List<SelectListItem> GetDegreeFamiliarity();
}