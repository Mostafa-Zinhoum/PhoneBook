using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PhB.Web.Models;
using System.Globalization;

namespace PhB.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStringLocalizer<AccountController> localizer;
        private readonly UserManager<IdentityUser> userManager;
        public SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signInManager
            , IStringLocalizer<AccountController> _localizer)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            localizer = _localizer; 
        }

        

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration() 
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(IdentityUserModel account)
        {
            if (ModelState.IsValid)
            {
                var result = await userManager.CreateAsync(new IdentityUser { Email = account.Email, UserName = account.UserName }, account.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                        ModelState.AddModelError("", item.Description);
                }
            }

            return View(account);   
        }

        [HttpGet]
        public IActionResult login()
        {
            var cookie = Request.Cookies["Language"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(LoginModel login,string ReturnUrl= "~/PhoneBook/Index")
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(login.UserName);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, login.Password, login.Rememberme, false);
                    if (result.Succeeded)
                        return LocalRedirect(ReturnUrl);
                    else
                        ModelState.AddModelError("", "Invalid username & Password");
                }
                else
                    ModelState.AddModelError("", "Invalid username & Password");
            }
            return View(login);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return View("login");
        }

    }
}
