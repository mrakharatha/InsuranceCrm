using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Application.Services;
using Crm.Application.Utilities;
using Crm.Domain.ViewModel.Customer;
using Crm.Domain.ViewModel.DataTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMaritalStatusService _maritalStatusService;
        private readonly IAreaService _areaService;
        private readonly IPermissionService _permissionService;
        public CustomerController(ICustomerService customerService, IMaritalStatusService maritalStatusService, IAreaService areaService, IPermissionService permissionService)
        {
            _customerService = customerService;
            _maritalStatusService = maritalStatusService;
            _areaService = areaService;
            _permissionService = permissionService;
        }
        [PermissionChecker(16)]
        public IActionResult Index()
        {
            return View();
        }

        [PermissionChecker(17)]
        public IActionResult CustomerCreate()
        {
            GetData();
            return View();
        }


        [HttpPost]
        public IActionResult CustomerCreate(AddCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return View(model);
            }

            _customerService.AddCustomer(model);

            return RedirectToAction("Index");
        }

        [PermissionChecker(18)]
        public IActionResult CustomerEdit(int id)
        {
            var customer = _customerService.GetCustomerViewModel(id);

            if(customer==null)
                return RedirectToAction("Index");

            GetData(customer.ProvinceId);
            return View(customer);
        }

        [HttpPost]
        public IActionResult CustomerEdit(EditCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return View(model);
            }

            _customerService.UpdateCustomer(model);

            return RedirectToAction("Index");
        }

        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(19, User.GetUserId()))
                return false;

            _customerService.DeleteCustomer(id, User.GetUserId());

            return true;
        }

        public bool IsNationalCodeExist(string nationalCode,int customerId)
        {
            var isNationalCodeExist = _customerService.IsNationalCodeExist(customerId, nationalCode);
            return !isNationalCodeExist;
        }

        public bool IsPhoneNumberExist(string phoneNumber, int customerId)
        {
            var isPhoneNumberExist = _customerService.IsPhoneNumberExist(customerId, phoneNumber);
            return !isPhoneNumberExist;
        }


        public IActionResult GetTownship(int id)
        {
            return new JsonResult(_areaService.GetTownships(id));
        }
        public void GetData(int? provinceId=null)
        {
            ViewData["MaritalStatus"] = new SelectList(_maritalStatusService.GetMaritalStatus(), "Value", "Text");
            ViewData["Province"] = new SelectList(_areaService.GetProvinces(), "Value", "Text");

            if(provinceId != null)
                ViewData["Township"] = new SelectList(_areaService.GetTownships(provinceId.Value), "Value", "Text");
        }


        [HttpPost]
        public async Task<IActionResult> Data(DtParameters dtParameters)
        {
            var dtResult = await _customerService.GetData(dtParameters);

            return Json(dtResult);
        }
    }

}
