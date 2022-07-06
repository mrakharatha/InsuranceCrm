using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Interfaces;

public interface IIntroducedService
{
    List<Introduced> GetIntroducedsByInsuredId(int insuredId);
    void AddIntroduced(Introduced introduced);
    Introduced? GetIntroducedByIntroducedId(int introducedId);
    void UpdateIntroduced(Introduced introduced);
    void DeleteIntroduced(int introducedId, int userId);
}