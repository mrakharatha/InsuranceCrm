using Crm.Domain.Models;
using Crm.Domain.Models.PaymentMethod;

namespace Crm.Domain.Interfaces;

public interface IPaymentMethodRepository
{
    List<PaymentMethod> GetAllPaymentMethod();
    PaymentMethod? GetPaymentMethodById(int paymentMethodId);

    void AddPaymentMethod(PaymentMethod paymentMethod);
    void UpdatePaymentMethod(PaymentMethod paymentMethod);

    bool CheckCodePaymentMethod(int paymentMethodId, int code);
}