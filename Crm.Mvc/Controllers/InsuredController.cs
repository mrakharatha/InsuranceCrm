using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Domain.ViewModel.DataTable;
using Microsoft.AspNetCore.Mvc;

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
        public InsuredController(IInsuredService insuredService, IPermissionService permissionService, IInstallmentService installmentService, IPaymentMethodService paymentMethodService, ITermInsuranceService termInsuranceService, IInsuranceService insuranceService)
        {
            _insuredService = insuredService;
            _permissionService = permissionService;
            _installmentService = installmentService;
            _paymentMethodService = paymentMethodService;
            _termInsuranceService = termInsuranceService;
            _insuranceService = insuranceService;
        }

        [PermissionChecker(36)]
        public IActionResult Index()
        {
            return View();
        }

        [PermissionChecker(37)]
        public IActionResult InsuredCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Data(DtParameters dtParameters)
        {
            var dtResult = await _insuredService.GetData(dtParameters);

            return Json(dtResult);
        }




        public void GetData()
        {
            var installments = _installmentService.GetInstallment();
            var paymentMethods = _paymentMethodService.GetPaymentMethod();
            var termInsurances = _termInsuranceService.GetTermInsurance();
            var insurances = _insuranceService.GetInsurance();
        }
    }
}
