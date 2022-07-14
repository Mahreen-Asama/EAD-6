using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Asp.Net_Core_Identity.ViewModels;

namespace Asp.Net_Core_Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> uManager,
                                 SignInManager<IdentityUser> sManager)
        {
            userManager = uManager;
            signInManager = sManager;
        }

        //-------------signup-------------
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                };
                var result = await userManager.CreateAsync(user,
                                                         model.Password);

                if (result.Succeeded)
                {
                    if (signInManager.IsSignedIn(User))
                    {
                        return RedirectToAction("index", "home");
                    }
                    return RedirectToAction("login", "account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        //------login-----------
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    }
}
