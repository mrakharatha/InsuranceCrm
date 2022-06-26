using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Application.Utilities;
using Crm.Domain.Models;
using Crm.Domain.Models.Insurance;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    public class RatioController : Controller
    {
        private readonly IRatioService _ratioService;
        private readonly IPermissionService _permissionService;

        public RatioController(IRatioService ratioService, IPermissionService permissionService)
        {
            _ratioService = ratioService;
            _permissionService = permissionService;
        }

        [PermissionChecker(40)]
        public IActionResult Index()
        {
            return View(_ratioService.GetAllRatio());
        }

        [PermissionChecker(41)]
        public IActionResult RatioCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RatioCreate(Ratio ratio)
        {
            if (!ModelState.IsValid)
                return View(ratio);

            if (_ratioService.CheckCodeRatio(0, ratio.Code.Value))
            {
                ModelState.AddModelError(nameof(ratio.Code), "کد وارد شده تکرای است");
                return View(ratio);
            }

            _ratioService.AddRatio(ratio);

            return RedirectToAction("Index");
        }


        [PermissionChecker(42)]
        public IActionResult RatioEdit(int id)
        {
            var ratio = _ratioService.GetRatioById(id);

            if (ratio == null)
                return RedirectToAction("Index");

            return View(ratio);
        }

        [HttpPost]
        public IActionResult RatioEdit(Ratio ratio)
        {
            if (!ModelState.IsValid)
                return View(ratio);

            if (_ratioService.CheckCodeRatio(ratio.RatioId, ratio.Code.Value))
            {
                ModelState.AddModelError(nameof(ratio.Code), "کد وارد شده تکرای است");
                return View(ratio);
            }

            _ratioService.UpdateRatio(ratio);

            return RedirectToAction("Index");
        }

        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(43, User.GetUserId()))
                return false;

            _ratioService.DeleteRatio(id);

            return true;
        }
    }
}
