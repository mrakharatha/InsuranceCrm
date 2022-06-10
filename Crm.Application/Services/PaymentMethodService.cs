using Crm.Application.Interfaces;
using Crm.Domain.Interfaces;
using Crm.Domain.Models.PaymentMethod;

namespace Crm.Application.Services;

public class PaymentMethodService: IPaymentMethodService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;

    public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
    {
        _paymentMethodRepository = paymentMethodRepository;
    }


    public List<PaymentMethod> GetAllPaymentMethod()
    {
        return _paymentMethodRepository.GetAllPaymentMethod();
    }

    public PaymentMethod? GetPaymentMethodById(int paymentMethodId)
    {
        return _paymentMethodRepository.GetPaymentMethodById(paymentMethodId);
    }

    public void AddPaymentMethod(PaymentMethod paymentMethod)
    {
        _paymentMethodRepository.AddPaymentMethod(paymentMethod);
    }

    public void UpdatePaymentMethod(PaymentMethod paymentMethod)
    {
        paymentMethod.UpdateDate = DateTime.Now;
        _paymentMethodRepository.UpdatePaymentMethod(paymentMethod);
    }

    public void DeletePaymentMethod(int paymentMethodId)
    {
        var paymentMethod = GetPaymentMethodById(paymentMethodId);

        if (paymentMethod == null)
            return;

        paymentMethod.DeleteDate = DateTime.Now;
        UpdatePaymentMethod(paymentMethod);
    }

    public bool CheckCodePaymentMethod(int paymentMethodId, int code)
    {
        return _paymentMethodRepository.CheckCodePaymentMethod(paymentMethodId, code);
    }
}