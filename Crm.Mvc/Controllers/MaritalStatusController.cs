using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Application.Utilities;
using Crm.Domain.Models.MaritalStatus;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    public class MaritalStatusController : Controller
    {
        private readonly IMaritalStatusService _maritalStatusService;
        private readonly IPermissionService _permissionService;

        public MaritalStatusController(IMaritalStatusService maritalStatusService, IPermissionService permissionService)
        {
            _maritalStatusService = maritalStatusService;
            _permissionService = permissionService;
        }

        [PermissionChecker(12)]
        public IActionResult Index()
        {
            return View(_maritalStatusService.GetAllMaritalStatus());
        }

        [PermissionChecker(13)]
        public IActionResult MaritalStatusCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MaritalStatusCreate(MaritalStatus maritalStatus)
        {
            if (!ModelState.IsValid)
                return View(maritalStatus);

            if (_maritalStatusService.CheckCodeMaritalStatus(0, maritalStatus.Code.Value))
            {
                ModelState.AddModelError(nameof(maritalStatus.Code), "کد وارد شده تکرای است");
                return View(maritalStatus);
            }

            _maritalStatusService.AddMaritalStatus(maritalStatus);

            return RedirectToAction("Index");
        }


        [PermissionChecker(14)]
        public IActionResult MaritalStatusEdit(int id)
        {
            var maritalStatus = _maritalStatusService.GetMaritalStatusById(id);

            if (maritalStatus == null)
                return RedirectToAction("Index");

            return View(maritalStatus);
        }

        [HttpPost]
        public IActionResult MaritalStatusEdit(MaritalStatus maritalStatus)
        {
            if (!ModelState.IsValid)
                return View(maritalStatus);

            if (_maritalStatusService.CheckCodeMaritalStatus(maritalStatus.MaritalStatusId, maritalStatus.Code.Value))
            {
                ModelState.AddModelError(nameof(maritalStatus.Code), "کد وارد شده تکرای است");
                return View(maritalStatus);
            }

            _maritalStatusService.UpdateMaritalStatus(maritalStatus);

            return RedirectToAction("Index");
        }

        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(15, User.GetUserId()))
                return false;

            _maritalStatusService.DeleteMaritalStatus(id);

            return true;

        }

    }
}
