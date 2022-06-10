using Crm.Domain.Interfaces;
using Crm.Domain.Models.PaymentMethod;
using Crm.Infra.Data.Context;

namespace Crm.Infra.Data.Repository;

public class PaymentMethodRepository: IPaymentMethodRepository
{
    private readonly ApplicationContext _context;

    public PaymentMethodRepository(ApplicationContext context)
    {
        _context = context;
    }


    public List<PaymentMethod> GetAllPaymentMethod()
    {
        return _context.PaymentMethods
            .OrderByDescending(x => x.PaymentMethodId)
            .ToList();
    }

    public PaymentMethod? GetPaymentMethodById(int paymentMethodId)
    {
        return _context.PaymentMethods.Find(paymentMethodId);
    }

    public void AddPaymentMethod(PaymentMethod paymentMethod)
    {
        _context.Add(paymentMethod);
        _context.SaveChanges();
    }

    public void UpdatePaymentMethod(PaymentMethod paymentMethod)
    {
        _context.Update(paymentMethod);
        _context.SaveChanges();
    }

    public bool CheckCodePaymentMethod(int paymentMethodId, int code)
    {

        if (paymentMethodId == 0)
            return _context.PaymentMethods.Any(x => x.Code == code);

        return _context.PaymentMethods.Any(x => x.Code == code && x.PaymentMethodId != paymentMethodId);

    }
}