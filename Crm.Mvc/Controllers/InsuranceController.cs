using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Application.Utilities;
using Crm.Domain.Models;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly IInsuranceService _insuranceService;
        private readonly IPermissionService _permissionService;

        public InsuranceController(IInsuranceService insuranceService, IPermissionService permissionService)
        {
            _insuranceService = insuranceService;
            _permissionService = permissionService;
        }

        [PermissionChecker(20)]
        public IActionResult Index()
        {
            return View(_insuranceService.GetAllInsurance());
        }

        [PermissionChecker(21)]
        public IActionResult InsuranceCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsuranceCreate(Insurance insurance)
        {
            if (!ModelState.IsValid)
                return View(insurance);

            if (_insuranceService.CheckCodeInsurance(0, insurance.Code.Value))
            {
                ModelState.AddModelError(nameof(insurance.Code), "کد وارد شده تکرای است");
                return View(insurance);
            }

            _insuranceService.AddInsurance(insurance);

            return RedirectToAction("Index");
        }


        [PermissionChecker(22)]
        public IActionResult InsuranceEdit(int id)
        {
            var insurance = _insuranceService.GetInsuranceById(id);

            if (insurance == null)
                return RedirectToAction("Index");

            return View(insurance);
        }

        [HttpPost]
        public IActionResult InsuranceEdit(Insurance insurance)
        {
            if (!ModelState.IsValid)
                return View(insurance);

            if (_insuranceService.CheckCodeInsurance(insurance.InsuranceId, insurance.Code.Value))
            {
                ModelState.AddModelError(nameof(insurance.Code), "کد وارد شده تکرای است");
                return View(insurance);
            }

            _insuranceService.UpdateInsurance(insurance);

            return RedirectToAction("Index");
        }

        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(23, User.GetUserId()))
                return false;

            _insuranceService.DeleteInsurance(id);

            return true;

        }
    }
}
