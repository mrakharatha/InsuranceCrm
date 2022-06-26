using Crm.Domain.Interfaces;
using Crm.Domain.Models.Insurance;
using Crm.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Infra.Data.Repository;

public class RatioRepository: IRatioRepository
{
    private readonly ApplicationContext _context;

    public RatioRepository(ApplicationContext context)
    {
        _context = context;
    }


    public List<Ratio> GetAllRatio()
    {
        return _context.Ratios
            .OrderByDescending(x => x.RatioId)
            .ToList();
    }

    public Ratio? GetRatioById(int ratioId)
    {
        return _context.Ratios.Find(ratioId);
    }

    public void AddRatio(Ratio ratio)
    {
        _context.Add(ratio);
        _context.SaveChanges();
    }

    public void UpdateRatio(Ratio ratio)
    {
        _context.Update(ratio);
        _context.SaveChanges();
    }

    public bool CheckCodeRatio(int ratioId, int code)
    {

        if (ratioId == 0)
            return _context.Ratios.Any(x => x.Code == code);

        return _context.Ratios.Any(x => x.Code == code && x.RatioId != ratioId);

    }

    public List<SelectListItem> GetRatio()
    {
        return _context.Ratios
            .OrderByDescending(x => x.RatioId)
            .Select(x => new SelectListItem()
            {
                Value = x.RatioId.ToString(),
                Text = x.Title+" - "+x.Code
            })
            .ToList();
    }
}