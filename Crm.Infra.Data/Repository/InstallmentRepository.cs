using Crm.Domain.Interfaces;
using Crm.Domain.Models;
using Crm.Domain.Models.Installment;
using Crm.Infra.Data.Context;

namespace Crm.Infra.Data.Repository;

public class InstallmentRepository: IInstallmentRepository
{
    private readonly ApplicationContext _context;

    public InstallmentRepository(ApplicationContext context)
    {
        _context = context;
    }


    public List<Installment> GetAllInstallment()
    {
        return _context.Installments
            .OrderByDescending(x => x.InstallmentId)
            .ToList();
    }

    public Installment? GetInstallmentById(int installmentId)
    {
        return _context.Installments.Find(installmentId);
    }

    public void AddInstallment(Installment installment)
    {
        _context.Add(installment);
        _context.SaveChanges();
    }

    public void UpdateInstallment(Installment installment)
    {
        _context.Update(installment);
        _context.SaveChanges();
    }

    public bool CheckCodeInstallment(int installmentId, int code)
    {

        if (installmentId == 0)
            return _context.Installments.Any(x => x.Code == code);

        return _context.Installments.Any(x => x.Code == code && x.InstallmentId != installmentId);

    }
}