using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Application.Utilities;
using Crm.Domain.Models.Insurance;
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
        private readonly IIntroducedService _introducedService;
        private readonly IRatioService _ratioService;
        private readonly IDegreeFamiliarityService _degreeFamiliarityService;
        public InsuredController(IInsuredService insuredService, IPermissionService permissionService, IInstallmentService installmentService, IPaymentMethodService paymentMethodService, ITermInsuranceService termInsuranceService, IInsuranceService insuranceService, ICustomerService customerService, IIntroducedService introducedService, IDegreeFamiliarityService degreeFamiliarityService, IRatioService ratioService)
        {
            _insuredService = insuredService;
            _permissionService = permissionService;
            _installmentService = installmentService;
            _paymentMethodService = paymentMethodService;
            _termInsuranceService = termInsuranceService;
            _insuranceService = insuranceService;
            _customerService = customerService;
            _introducedService = introducedService;
            _degreeFamiliarityService = degreeFamiliarityService;
            _ratioService = ratioService;
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
            ViewBag.InsuredId = id;
            var introduceds = _introducedService.GetIntroducedsByInsuredId(id);
            return View(introduceds);
        }

        [PermissionChecker(50)]
        public IActionResult IntroducedCreate(int id)
        {
            ViewBag.InsuredId = id;
            GetDataIntroduced();
            return View();
        }

        [HttpPost]
        public IActionResult IntroducedCreate(Introduced introduced)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.InsuredId = introduced.InsuredId;
                GetDataIntroduced();
                return View(introduced);
            }

            _introducedService.AddIntroduced(introduced);

            return RedirectToAction("Introduced", new {id = introduced.InsuredId});
        }


        [PermissionChecker(51)]
        public IActionResult IntroducedEdit(int id,int insuredId)
        {
            var introduced = _introducedService.GetIntroducedByIntroducedId(id);

            if (introduced == null)
                return RedirectToAction("Introduced", new { id = insuredId });

            GetDataIntroduced();
            return View(introduced);
        }

        [HttpPost]
        public IActionResult IntroducedEdit(Introduced introduced)
        {
            if (!ModelState.IsValid)
            {
                GetDataIntroduced();
                return View(introduced);
            }

            _introducedService.UpdateIntroduced(introduced);
            return RedirectToAction("Introduced",new {id=introduced.InsuredId});
        }


        public bool IntroducedDelete(int id)
        {
            if (!_permissionService.CheckPermission(52, User.GetUserId()))
                return false;

            _introducedService.DeleteIntroduced(id, User.GetUserId());

            return true;
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

        public void GetDataIntroduced()
        {
            ViewData["DegreeFamiliarity"] = new SelectList(_degreeFamiliarityService.GetDegreeFamiliarities(), "Value", "Text");
            ViewData["Ratio"] = new SelectList(_ratioService.GetRatios(), "Value", "Text");
        }
 
   
    }
}
