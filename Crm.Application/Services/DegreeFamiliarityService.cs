using Crm.Application.Interfaces;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Application.Services;

public class DegreeFamiliarityService: IDegreeFamiliarityService
{
    private readonly IDegreeFamiliarityRepository _degreeFamiliarityRepository;

    public DegreeFamiliarityService(IDegreeFamiliarityRepository degreeFamiliarityRepository)
    {
        _degreeFamiliarityRepository = degreeFamiliarityRepository;
    }


    public List<DegreeFamiliarity> GetAllDegreeFamiliarity()
    {
        return _degreeFamiliarityRepository.GetAllDegreeFamiliarity();
    }

    public DegreeFamiliarity? GetDegreeFamiliarityById(int degreeFamiliarityId)
    {
        return _degreeFamiliarityRepository.GetDegreeFamiliarityById(degreeFamiliarityId);
    }

    public void AddDegreeFamiliarity(DegreeFamiliarity degreeFamiliarity)
    {
        _degreeFamiliarityRepository.AddDegreeFamiliarity(degreeFamiliarity);
    }

    public void UpdateDegreeFamiliarity(DegreeFamiliarity degreeFamiliarity)
    {
        degreeFamiliarity.UpdateDate = DateTime.Now;
        _degreeFamiliarityRepository.UpdateDegreeFamiliarity(degreeFamiliarity);
    }

    public void DeleteDegreeFamiliarity(int degreeFamiliarityId)
    {
        var degreeFamiliarity = GetDegreeFamiliarityById(degreeFamiliarityId);

        if (degreeFamiliarity == null)
            return;

        degreeFamiliarity.DeleteDate = DateTime.Now;
        UpdateDegreeFamiliarity(degreeFamiliarity);
    }

    public bool CheckCodeDegreeFamiliarity(int degreeFamiliarityId, int code)
    {
        return _degreeFamiliarityRepository.CheckCodeDegreeFamiliarity(degreeFamiliarityId, code);
    }

    public List<SelectListItem> GetDegreeFamiliarities()
    {
        var result = _degreeFamiliarityRepository.GetDegreeFamiliarities();

        var items = new List<SelectListItem>()
        {
            new SelectListItem(){Value = null,Text = "لطفا انتخاب کنید"}
        };

        items.AddRange(result);
        return items;
    }
}