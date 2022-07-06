using Crm.Domain.Models.Insurance;

namespace Crm.Domain.Interfaces;

public interface IIntroducedRepository
{
    List<Introduced> GetIntroducedsByInsuredId(int insuredId);
    void AddIntroduced(Introduced introduced);
    Introduced? GetIntroducedByIntroducedId(int introducedId);
    void UpdateIntroduced(Introduced introduced);

}