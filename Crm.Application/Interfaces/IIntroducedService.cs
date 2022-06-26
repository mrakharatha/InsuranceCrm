using Crm.Domain.Models.Insurance;

namespace Crm.Application.Interfaces;

public interface IIntroducedService
{
    List<Introduced> GetIntroducedsByInsuredId(int insuredId);
}