using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Domain.Interfaces;

public interface IAreaRepository
{
    List<SelectListItem> GetProvinces();
    List<SelectListItem> GetTownships(int provinceId);
}