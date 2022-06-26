using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Application.Utilities;
using Crm.Domain.Models;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    public class DegreeFamiliarityController : Controller
    {
        private readonly IDegreeFamiliarityService _degreeFamiliarityService;
        private readonly IPermissionService _permissionService;

        public DegreeFamiliarityController(IDegreeFamiliarityService degreeFamiliarityService, IPermissionService permissionService)
        {
            _degreeFamiliarityService = degreeFamiliarityService;
            _permissionService = permissionService;
        }

        [PermissionChecker(44)]
        public IActionResult Index()
        {
            return View(_degreeFamiliarityService.GetAllDegreeFamiliarity());
        }

        [PermissionChecker(41)]
        public IActionResult DegreeFamiliarityCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DegreeFamiliarityCreate(DegreeFamiliarity degreeFamiliarity)
        {
            if (!ModelState.IsValid)
                return View(degreeFamiliarity);

            if (_degreeFamiliarityService.CheckCodeDegreeFamiliarity(0, degreeFamiliarity.Code.Value))
            {
                ModelState.AddModelError(nameof(degreeFamiliarity.Code), "کد وارد شده تکرای است");
                return View(degreeFamiliarity);
            }

            _degreeFamiliarityService.AddDegreeFamiliarity(degreeFamiliarity);

            return RedirectToAction("Index");
        }


        [PermissionChecker(45)]
        public IActionResult DegreeFamiliarityEdit(int id)
        {
            var degreeFamiliarity = _degreeFamiliarityService.GetDegreeFamiliarityById(id);

            if (degreeFamiliarity == null)
                return RedirectToAction("Index");

            return View(degreeFamiliarity);
        }

        [HttpPost]
        public IActionResult DegreeFamiliarityEdit(DegreeFamiliarity degreeFamiliarity)
        {
            if (!ModelState.IsValid)
                return View(degreeFamiliarity);

            if (_degreeFamiliarityService.CheckCodeDegreeFamiliarity(degreeFamiliarity.DegreeFamiliarityId, degreeFamiliarity.Code.Value))
            {
                ModelState.AddModelError(nameof(degreeFamiliarity.Code), "کد وارد شده تکرای است");
                return View(degreeFamiliarity);
            }

            _degreeFamiliarityService.UpdateDegreeFamiliarity(degreeFamiliarity);

            return RedirectToAction("Index");
        }

        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(46, User.GetUserId()))
                return false;

            _degreeFamiliarityService.DeleteDegreeFamiliarity(id);

            return true;
        }
    }
}
