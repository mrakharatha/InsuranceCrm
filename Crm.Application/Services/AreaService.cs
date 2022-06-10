using Crm.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Services;

public class AreaService: IAreaService
{
    private  readonly IAreaRepository _areaRepository;

    public AreaService(IAreaRepository areaRepository)
    {
        _areaRepository = areaRepository;
    }

    public List<SelectListItem> GetProvinces()
    {
        var result = _areaRepository.GetProvinces();

        var items = new List<SelectListItem>()
        {
            new SelectListItem(){Value = null,Text = "لطفا انتخاب کنید"}
        };

        items.AddRange(result);
        return items;
    }

    public List<SelectListItem> GetTownships(int provinceId)
    {
        var result = _areaRepository.GetTownships(provinceId);

        var items = new List<SelectListItem>()
        {
            new SelectListItem(){Value = null,Text = "لطفا انتخاب کنید"}
        };

        items.AddRange(result);
        return items;
    }
}