using Crm.Domain.Interfaces;
using Crm.Domain.Models.Insurance;
using Crm.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infra.Data.Repository;

public class IntroducedRepository: IIntroducedRepository
{
    private readonly ApplicationContext _context;

    public IntroducedRepository(ApplicationContext context)
    {
        _context = context;
    }

    public List<Introduced> GetIntroducedsByInsuredId(int insuredId)
    {
        return _context.Introduceds
            .Where(x => x.InsuredId.Equals(insuredId))
            .OrderByDescending(x => x.IntroducedId)
            .Include(x => x.Insured)
            .Include(x => x.Ratio)
            .Include(x => x.DegreeFamiliarity)
            .ToList();
    }

    public void AddIntroduced(Introduced introduced)
    {
        _context.Add(introduced);
        _context.SaveChanges();
    }

    public Introduced? GetIntroducedByIntroducedId(int introducedId)
    {
        return _context.Introduceds.Find(introducedId);
    }

    public void UpdateIntroduced(Introduced introduced)
    {
        _context.Update(introduced);
        _context.SaveChanges();
    }
}