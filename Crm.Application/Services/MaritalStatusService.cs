using Crm.Application.Interfaces;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.MaritalStatus;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Services;

public class MaritalStatusService: IMaritalStatusService
{
    private readonly IMaritalStatusRepository _maritalStatusRepository;

    public MaritalStatusService(IMaritalStatusRepository maritalStatusRepository)
    {
        _maritalStatusRepository = maritalStatusRepository;
    }

    public List<MaritalStatus> GetAllMaritalStatus()
    {
        return _maritalStatusRepository.GetAllMaritalStatus();
    }

    public MaritalStatus? GetMaritalStatusById(int maritalStatusId)
    {
        return _maritalStatusRepository.GetMaritalStatusById(maritalStatusId);
    }

    public void AddMaritalStatus(MaritalStatus maritalStatus)
    {
        _maritalStatusRepository.AddMaritalStatus(maritalStatus);
    }

    public void UpdateMaritalStatus(MaritalStatus maritalStatus)
    {
        maritalStatus.UpdateDate=DateTime.Now;
        _maritalStatusRepository.UpdateMaritalStatus(maritalStatus);
    }

    public void DeleteMaritalStatus(int maritalStatusId)
    {
        var maritalStatus = GetMaritalStatusById(maritalStatusId);

        if(maritalStatus==null)
            return;

        maritalStatus.DeleteDate = DateTime.Now;
        UpdateMaritalStatus(maritalStatus);
    }

    public bool CheckCodeMaritalStatus(int maritalStatusId, int code)
    {
        return _maritalStatusRepository.CheckCodeMaritalStatus(maritalStatusId, code);
    }

    public List<SelectListItem> GetMaritalStatus()
    {
        var result = _maritalStatusRepository.GetMaritalStatus();

        var items = new List<SelectListItem>()
        {
            new SelectListItem(){Value = null,Text = "لطفا انتخاب کنید"}
        };

        items.AddRange(result);
        return items;
    }
}