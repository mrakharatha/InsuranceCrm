using System.Security.Claims;
using Crm.Application.Interfaces;
using Crm.Application.Utilities;
using Crm.Domain.ViewModel.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("Login")]
        public IActionResult Login(string? returnUrl = null)
        {
            if (returnUrl != null)
                ViewBag.returnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var user = _userService.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim("UserName", user.UserName)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);

                    if (login.ReturnUrl.HasValue() && Url.IsLocalUrl(login.ReturnUrl))
                        return Redirect(login.ReturnUrl);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(nameof(login.UserName), "حساب کاربری شما فعال نمی باشد");
            }


            ModelState.AddModelError(nameof(login.UserName), "کاربری با مشخصات وارد شده یافت نشد");
            return View(login);
        }


        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }


        #region ChangePassword
        [PermissionChecker(16)]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel change)
        {

            if (!ModelState.IsValid)
                return View(change);

            int currentUserId = User.GetUserId();


            if (!_userService.CompareOldPassword(currentUserId, change.OldPassword))
            {
                ModelState.AddModelError("OldPassword", "کلمه عبور فعلی صحیح نمی باشد");
                return View(change);
            }

            _userService.ChangeUserPassword(currentUserId, change.Password);

            return RedirectToAction("Login", "Account");
        }

        #endregion

         
        [Route("Permission")]
        public IActionResult Permission()
        {
            return View();
        }



    }
}
