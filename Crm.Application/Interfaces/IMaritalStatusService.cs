using Crm.Domain.Models.MaritalStatus;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Interfaces;

public interface IMaritalStatusService
{
    List<MaritalStatus> GetAllMaritalStatus();
    MaritalStatus? GetMaritalStatusById(int maritalStatusId);

    void AddMaritalStatus(MaritalStatus maritalStatus);
    void UpdateMaritalStatus(MaritalStatus maritalStatus);
    void DeleteMaritalStatus(int maritalStatusId);

    bool CheckCodeMaritalStatus(int maritalStatusId, int code);

    List<SelectListItem> GetMaritalStatus();

}