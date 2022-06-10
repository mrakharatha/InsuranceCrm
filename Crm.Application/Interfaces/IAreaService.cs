using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Services;

public interface IAreaService
{
    List<SelectListItem> GetProvinces();
    List<SelectListItem> GetTownships(int provinceId);
}