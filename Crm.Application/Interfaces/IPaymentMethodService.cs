using Crm.Domain.Models;
using Crm.Domain.Models.PaymentMethod;

namespace Crm.Application.Interfaces;

public interface IPaymentMethodService
{
    List<PaymentMethod> GetAllPaymentMethod();
    PaymentMethod? GetPaymentMethodById(int paymentMethodId);

    void AddPaymentMethod(PaymentMethod paymentMethod);
    void UpdatePaymentMethod(PaymentMethod paymentMethod);
    void DeletePaymentMethod(int paymentMethodId);

    bool CheckCodePaymentMethod(int paymentMethodId, int code);
}