using Crm.Domain.Models;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Interfaces;

public interface IRatioService
{
    List<Ratio> GetAllRatio();
    Ratio? GetRatioById(int ratioId);
    void AddRatio(Ratio ratio);
    void UpdateRatio(Ratio ratio);
    void DeleteRatio(int ratioId);
    bool CheckCodeRatio(int ratioId, int code);
    List<SelectListItem> GetRatio();
}