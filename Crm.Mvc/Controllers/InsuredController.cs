using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Application.Utilities;
using Crm.Domain.ViewModel.DataTable;
using Crm.Domain.ViewModel.Insured;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Mvc.Controllers
{
    public class InsuredController : Controller
    {
        private readonly IInsuredService _insuredService;
        private readonly IPermissionService _permissionService;
        private readonly IInstallmentService _installmentService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly ITermInsuranceService _termInsuranceService;
        private readonly IInsuranceService _insuranceService;
        private readonly ICustomerService _customerService;

        public InsuredController(IInsuredService insuredService, IPermissionService permissionService, IInstallmentService installmentService, IPaymentMethodService paymentMethodService, ITermInsuranceService termInsuranceService, IInsuranceService insuranceService, ICustomerService customerService)
        {
            _insuredService = insuredService;
            _permissionService = permissionService;
            _installmentService = installmentService;
            _paymentMethodService = paymentMethodService;
            _termInsuranceService = termInsuranceService;
            _insuranceService = insuranceService;
            _customerService = customerService;
        }

        [PermissionChecker(36)]
        public IActionResult Index()
        {
            return View();
        }

        [PermissionChecker(37)]
        public IActionResult InsuredCreate()
        {
            GetData();
            return View();
        }

        [HttpPost]
        public IActionResult InsuredCreate(AddInsuredViewModel model)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return View(model);
            }

            _insuredService.AddInsured(model);
            return RedirectToAction("Index");
        }

        [PermissionChecker(38)]
        public IActionResult InsuredEdit(int id)
        {
            var insured = _insuredService.GetInsuredViewModel(id);

            if (insured == null)
                return RedirectToAction("Index");

            GetData();
            return View(insured);
        }

        [HttpPost]
        public IActionResult InsuredEdit(EditInsuredViewModel model)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return View(model);
            }

            _insuredService.UpdateInsured(model);
            return RedirectToAction("Index");
        }


        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(39, User.GetUserId()))
                return false;

            _insuredService.DeleteInsured(id,User.GetUserId());

            return true;
        }


        [PermissionChecker(48)]
        public IActionResult Installments(int id)
        {
            var installments = _insuredService.GetInsuredInstallmentsByInsuredId(id);
            return View(installments);
        }




        #region Introduced

        [PermissionChecker(49)]
        public IActionResult Introduced(int id)
        {
            return View();
        }


        #endregion





        [HttpPost]
        public async Task<IActionResult> Data(DtParameters dtParameters)
        {
            var dtResult = await _insuredService.GetData(dtParameters);

            return Json(dtResult);
        }




        public void GetData()
        {
            ViewData["Installment"] = new SelectList(_installmentService.GetInstallment(), "Value", "Text");
            ViewData["PaymentMethod"] = new SelectList(_paymentMethodService.GetPaymentMethod(), "Value", "Text");
            ViewData["TermInsurance"] = new SelectList(_termInsuranceService.GetTermInsurance(), "Value", "Text");
            ViewData["Insurance"] = new SelectList(_insuranceService.GetInsurance(), "Value", "Text");
            ViewData["Customer"] = new SelectList(_customerService.GetCustomer(), "Value", "Text");
        }
    }
}
