using Crm.Domain.Interfaces;
using Crm.Domain.Models.Insurance;
using Crm.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infra.Data.Repository;

public class TermInsuranceRepository: ITermInsuranceRepository
{
    private readonly ApplicationContext _context;

    public TermInsuranceRepository(ApplicationContext context)
    {
        _context = context;
    }

    public List<TermInsurance> GetAllTermInsurance()
    {
        return _context.TermInsurances
            .OrderByDescending(x => x.TermInsuranceId)
            .ToList();
    }

    public TermInsurance? GetTermInsuranceById(int termInsuranceId)
    {
        return _context.TermInsurances.Find(termInsuranceId);
    }

    public void AddTermInsurance(TermInsurance termInsurance)
    {
        _context.Add(termInsurance);
        _context.SaveChanges();
    }

    public void UpdateTermInsurance(TermInsurance termInsurance)
    {
        _context.Update(termInsurance);
        _context.SaveChanges();
    }

    public bool CheckCodeTermInsurance(int termInsuranceId, int code)
    {

        if (termInsuranceId == 0)
            return _context.TermInsurances.Any(x => x.Code == code);

        return _context.TermInsurances.Any(x => x.Code == code && x.TermInsuranceId != termInsuranceId);

    }
}