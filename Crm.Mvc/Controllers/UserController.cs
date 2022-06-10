using Crm.Application.Interfaces;
using Crm.Application.Security;
using Crm.Application.Utilities;
using Crm.Domain.Models.User;
using Crm.Domain.ViewModel.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;
        public UserController(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        [PermissionChecker(3)]
        public IActionResult Index()
        {
            return View(_userService.GetAllUsers());
        }

        [PermissionChecker(4)]
        public IActionResult UserCreate()
        {
            GetData();
            return View();
        }


        [HttpPost]
        public IActionResult UserCreate(User user, List<int> selectedRoles)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return View(user);

            }

            if (_userService.IsExistUserName(0,user.UserName))
            {
                ModelState.AddModelError(nameof(user.UserName), "نام کاربری معتبر نمی باشد");
                GetData();
                return View(user);
            }

            _userService.AddUser(user);

            _permissionService.AddUserRole(user.UserId, selectedRoles);

            return RedirectToAction("Index");
        }


        [PermissionChecker(5)]
        public IActionResult UserEdit(int id)
        {
            if (id == 1)
                return RedirectToAction("Index");

            var model = _userService.GetUserViewModel(id);
            if (model == null)
                return RedirectToAction("Index");


            GetData();
            return View(model);
        }


        [HttpPost]
        public IActionResult UserEdit(UserViewModel user, List<int> selectedRoles)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                user.UserRoles = selectedRoles;
                return View(user);

            }


            if (_userService.IsExistUserName(user.UserId, user.UserName))
            {
                ModelState.AddModelError(nameof(user.UserName), "نام کاربری معتبر نمی باشد");
                GetData();
                user.UserRoles = selectedRoles;
                return View(user);
            }

            _userService.UpdateUser(user);

            _permissionService.UpdateUserRole(user.UserId, selectedRoles);

            return RedirectToAction("Index");
        }


        public bool Delete(int id)
        {
            if (!_permissionService.CheckPermission(6, User.GetUserId()))
                return false;

            if (_userService.DeleteUser(id))
                _permissionService.DeleteUserRole(id);

            return true;

        }


        public void GetData()
        {
            ViewData["Roles"] = _permissionService.GetRoles();

            List<SelectListItem> status = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "True",
                    Text = "فعال"
                }, new SelectListItem()
                {
                    Value = "False",
                    Text = "غیرفعال"
                }
            };

            ViewData["Status"] = new SelectList(status, "Value", "Text");
        }
    }
}
