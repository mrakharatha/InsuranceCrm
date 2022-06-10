using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Application.Utilities;
using Crm.Domain.Models;
using Crm.Domain.Models.PaymentMethod;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IPermissionService _permissionService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService, IPermissionService permissionService)
        {
            _paymentMethodService = paymentMethodService;
            _permissionService = permissionService;
        }

        [PermissionChecker(24)]
        public IActionResult Index()
        {
            return View(_paymentMethodService.GetAllPaymentMethod());
        }

        [PermissionChecker(25)]
        public IActionResult PaymentMethodCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PaymentMethodCreate(PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
                return View(paymentMethod);

            if (_paymentMethodService.CheckCodePaymentMethod(0, paymentMethod.Code.Value))
            {
                ModelState.AddModelError(nameof(paymentMethod.Code), "کد وارد شده تکرای است");
                return View(paymentMethod);
            }

            _paymentMethodService.AddPaymentMethod(paymentMethod);

            return RedirectToAction("Index");
        }


        [PermissionChecker(26)]
        public IActionResult PaymentMethodEdit(int id)
        {
            var paymentMethod = _paymentMethodService.GetPaymentMethodById(id);

            if (paymentMethod == null)
                return RedirectToAction("Index");

            return View(paymentMethod);
        }

        [HttpPost]
        public IActionResult PaymentMethodEdit(PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
                return View(paymentMethod);

            if (_paymentMethodService.CheckCodePaymentMethod(paymentMethod.PaymentMethodId, paymentMethod.Code.Value))
            {
                ModelState.AddModelError(nameof(paymentMethod.Code), "کد وارد شده تکرای است");
                return View(paymentMethod);
            }

            _paymentMethodService.UpdatePaymentMethod(paymentMethod);

            return RedirectToAction("Index");
        }

        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(27, User.GetUserId()))
                return false;

            _paymentMethodService.DeletePaymentMethod(id);

            return true;

        }
    }
}
