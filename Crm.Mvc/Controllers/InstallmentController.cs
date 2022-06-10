using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Application.Services;
using Crm.Application.Utilities;
using Crm.Domain.Models.Installment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Mvc.Controllers
{
    public class InstallmentController : Controller
    {
        private readonly IInstallmentService _installmentService;
        private readonly IPermissionService _permissionService;
        public InstallmentController(IInstallmentService installmentService, IPermissionService permissionService)
        {
            _installmentService = installmentService;
            _permissionService = permissionService;
        }

        [PermissionChecker(28)]
        public IActionResult Index()
        {
            return View(_installmentService.GetAllInstallment());
        }

        [PermissionChecker(29)]
        public IActionResult InstallmentCreate()
        {
            GetData();
            return View();
        }


        [HttpPost]
        public IActionResult InstallmentCreate(Installment installment)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return View(installment);
            }

            if (_installmentService.CheckCodeInstallment(0, installment.Code.Value))
            {
                GetData();
                ModelState.AddModelError(nameof(installment.Code), "کد وارد شده تکرای است");
                return View(installment);
            }

            _installmentService.AddInstallment(installment);

            return RedirectToAction("Index");
        }

        [PermissionChecker(29)]
        public IActionResult InstallmentEdit(int id)
        {
            var installment = _installmentService.GetInstallmentById(id);

            if (installment == null)
                return RedirectToAction("Index");

            GetData();
            return View(installment);
        }

        [HttpPost]
        public IActionResult InstallmentEdit(Installment installment)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return View(installment);
            }
            if (_installmentService.CheckCodeInstallment(installment.InstallmentId, installment.Code.Value))
            {
                GetData();
                ModelState.AddModelError(nameof(installment.Code), "کد وارد شده تکرای است");
                return View(installment);
            }

            _installmentService.UpdateInstallment(installment);

            return RedirectToAction("Index");
        }
        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(30, User.GetUserId()))
                return false;

            _installmentService.DeleteInstallment(id);

            return true;

        }

        public void GetData()
        {
            ViewData["TypeSystem"] = new SelectList(_installmentService.GetTypeSystem(), "Value", "Text");
        }
    }
}
