using Crm.Application.Interfaces;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Services;

public class RatioService: IRatioService
{
    private readonly IRatioRepository _ratioRepository;

    public RatioService(IRatioRepository ratioRepository)
    {
        _ratioRepository = ratioRepository;
    }


    public List<Ratio> GetAllRatio()
    {
        return _ratioRepository.GetAllRatio();
    }

    public Ratio? GetRatioById(int ratioId)
    {
        return _ratioRepository.GetRatioById(ratioId);
    }

    public void AddRatio(Ratio ratio)
    {
        _ratioRepository.AddRatio(ratio);
    }

    public void UpdateRatio(Ratio ratio)
    {
        ratio.UpdateDate = DateTime.Now;
        _ratioRepository.UpdateRatio(ratio);
    }

    public void DeleteRatio(int ratioId)
    {
        var ratio = GetRatioById(ratioId);

        if (ratio == null)
            return;

        ratio.DeleteDate = DateTime.Now;
        UpdateRatio(ratio);
    }

    public bool CheckCodeRatio(int ratioId, int code)
    {
        return _ratioRepository.CheckCodeRatio(ratioId, code);
    }

    public List<SelectListItem> GetRatios()
    {
        var result = _ratioRepository.GetRatios();

        var items = new List<SelectListItem>()
        {
            new SelectListItem(){Value = null,Text = "لطفا انتخاب کنید"}
        };

        items.AddRange(result);
        return items;
    }
}