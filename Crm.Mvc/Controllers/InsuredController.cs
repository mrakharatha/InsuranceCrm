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
        public InsuredController(IInsuredService insuredService, IPermissionService permissionService)
        {
            _insuredService = insuredService;
            _permissionService = permissionService;
        }

        [PermissionChecker(36)]
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Data(DtParameters dtParameters)
        {
            var dtResult = await _insuredService.GetData(dtParameters);

            return Json(dtResult);
        }
    }
}
