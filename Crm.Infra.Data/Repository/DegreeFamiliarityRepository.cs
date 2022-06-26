using Crm.Domain.Interfaces;
using Crm.Domain.Models.Insurance;
using Crm.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Infra.Data.Repository;

public class DegreeFamiliarityRepository: IDegreeFamiliarityRepository
{
    private readonly ApplicationContext _context;

    public DegreeFamiliarityRepository(ApplicationContext context)
    {
        _context = context;
    }


    public List<DegreeFamiliarity> GetAllDegreeFamiliarity()
    {
        return _context.DegreeFamiliarities
            .OrderByDescending(x => x.DegreeFamiliarityId)
            .ToList();
    }

    public DegreeFamiliarity? GetDegreeFamiliarityById(int degreeFamiliarityId)
    {
        return _context.DegreeFamiliarities.Find(degreeFamiliarityId);
    }

    public void AddDegreeFamiliarity(DegreeFamiliarity degreeFamiliarity)
    {
        _context.Add(degreeFamiliarity);
        _context.SaveChanges();
    }

    public void UpdateDegreeFamiliarity(DegreeFamiliarity degreeFamiliarity)
    {
        _context.Update(degreeFamiliarity);
        _context.SaveChanges();
    }

    public bool CheckCodeDegreeFamiliarity(int degreeFamiliarityId, int code)
    {

        if (degreeFamiliarityId == 0)
            return _context.DegreeFamiliarities.Any(x => x.Code == code);

        return _context.DegreeFamiliarities.Any(x => x.Code == code && x.DegreeFamiliarityId != degreeFamiliarityId);

    }

    public List<SelectListItem> GetDegreeFamiliarity()
    {
        return _context.DegreeFamiliarities
            .OrderByDescending(x => x.DegreeFamiliarityId)
            .Select(x => new SelectListItem()
            {
                Value = x.DegreeFamiliarityId.ToString(),
                Text = x.Title+" - "+x.Code
            })
            .ToList();
    }
}