using Crm.Domain.Models;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Domain.Interfaces;

public interface IRatioRepository
{
    List<Ratio> GetAllRatio();
    Ratio? GetRatioById(int ratioId);
    void AddRatio(Ratio ratio);
    void UpdateRatio(Ratio ratio);
    bool CheckCodeRatio(int ratioId, int code);
    List<SelectListItem> GetRatio();
}