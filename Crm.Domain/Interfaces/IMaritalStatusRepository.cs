using Crm.Domain.Models.MaritalStatus;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Domain.Interfaces;

public interface IMaritalStatusRepository
{
    List<MaritalStatus> GetAllMaritalStatus();
    MaritalStatus? GetMaritalStatusById(int maritalStatusId);

    void AddMaritalStatus(MaritalStatus maritalStatus);
    void UpdateMaritalStatus(MaritalStatus maritalStatus);

    bool CheckCodeMaritalStatus(int maritalStatusId, int code);
    List<SelectListItem> GetMaritalStatus();

}