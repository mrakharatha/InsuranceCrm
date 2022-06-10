using Crm.Domain.Interfaces;
using Crm.Domain.Models;
using Crm.Domain.Models.Insurance;
using Crm.Infra.Data.Context;

namespace Crm.Infra.Data.Repository;

public class InsuranceRepository: IInsuranceRepository
{
    private readonly ApplicationContext _context;

    public InsuranceRepository(ApplicationContext context)
    {
        _context = context;
    }


    public List<Insurance> GetAllInsurance()
    {
        return _context.Insurance
            .OrderByDescending(x => x.InsuranceId)
            .ToList();
    }

    public Insurance? GetInsuranceById(int insuranceId)
    {
        return _context.Insurance.Find(insuranceId);
    }

    public void AddInsurance(Insurance insurance)
    {
        _context.Add(insurance);
        _context.SaveChanges();
    }

    public void UpdateInsurance(Insurance insurance)
    {
        _context.Update(insurance);
        _context.SaveChanges();
    }

    public bool CheckCodeInsurance(int insuranceId, int code)
    {

        if (insuranceId == 0)
            return _context.Insurance.Any(x => x.Code == code);

        return _context.Insurance.Any(x => x.Code == code && x.InsuranceId != insuranceId);

    }
}