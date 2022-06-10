using Crm.Application.Interfaces;
using Crm.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPermissionService _permissionService;

        public HomeController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public IActionResult Index()
        {
            if (_permissionService.CheckPermission(1, User.GetUserId()))
                return View();

            return RedirectToAction("IndexNotPermission");
        }

        public IActionResult IndexNotPermission()
        {
            return View();
        }
    }
}
