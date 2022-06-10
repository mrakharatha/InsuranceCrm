using Crm.Domain.Interfaces;
using Crm.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Infra.Data.Repository;

public class AreaRepository: IAreaRepository
{
    private readonly ApplicationContext _context;

    public AreaRepository(ApplicationContext context)
    {
        _context = context;
    }

    public List<SelectListItem> GetProvinces()
    {
        return _context.Provinces.Select(x => new SelectListItem()
        {
            Value = x.ProvinceId.ToString(),
            Text = x.ProvinceName
        }).ToList();
    }

    public List<SelectListItem> GetTownships(int provinceId)
    {
        return _context.Townships.Where(x=> x.ProvinceId==provinceId).Select(x => new SelectListItem()
        {
            Value = x.TownshipId.ToString(),
            Text = x.TownshipName
        }).ToList();
    }
}