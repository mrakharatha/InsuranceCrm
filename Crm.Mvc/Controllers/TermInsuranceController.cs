using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Application.Utilities;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Mvc.Controllers
{
    public class TermInsuranceController : Controller
    {
        private readonly ITermInsuranceService _termInsuranceService;
        private readonly IPermissionService _permissionService;
        public TermInsuranceController(ITermInsuranceService termInsuranceService, IPermissionService permissionService)
        {
            _termInsuranceService = termInsuranceService;
            _permissionService = permissionService;
        }

        [PermissionChecker(32)]
        public IActionResult Index()
        {
            return View(_termInsuranceService.GetAllTermInsurance());
        }

        [PermissionChecker(33)]
        public IActionResult TermInsuranceCreate()
        {
            GetData();
            return View();
        }


        [HttpPost]
        public IActionResult TermInsuranceCreate(TermInsurance termInsurance)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return View(termInsurance);
            }

            if (_termInsuranceService.CheckCodeTermInsurance(0, termInsurance.Code.Value))
            {
                GetData();
                ModelState.AddModelError(nameof(termInsurance.Code), "کد وارد شده تکرای است");
                return View(termInsurance);
            }

            _termInsuranceService.AddTermInsurance(termInsurance);

            return RedirectToAction("Index");
        }

        [PermissionChecker(34)]
        public IActionResult TermInsuranceEdit(int id)
        {
            var termInsurance = _termInsuranceService.GetTermInsuranceById(id);

            if (termInsurance == null)
                return RedirectToAction("Index");

            GetData();
            return View(termInsurance);
        }

        [HttpPost]
        public IActionResult TermInsuranceEdit(TermInsurance termInsurance)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return View(termInsurance);
            }
            if (_termInsuranceService.CheckCodeTermInsurance(termInsurance.TermInsuranceId, termInsurance.Code.Value))
            {
                GetData();
                ModelState.AddModelError(nameof(termInsurance.Code), "کد وارد شده تکرای است");
                return View(termInsurance);
            }

            _termInsuranceService.UpdateTermInsurance(termInsurance);

            return RedirectToAction("Index");
        }
        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(35, User.GetUserId()))
                return false;

            _termInsuranceService.DeleteTermInsurance(id);

            return true;

        }

        public void GetData()
        {
            ViewData["TypeSystem"] = new SelectList(_termInsuranceService.GetTypeSystem(), "Value", "Text");
        }
    }
}
