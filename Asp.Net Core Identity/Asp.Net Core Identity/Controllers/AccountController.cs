using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Asp.Net_Core_Identity.ViewModels;
using Asp.Net_Core_Identity.Models;

namespace Asp.Net_Core_Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> uManager,
                                 SignInManager<ApplicationUser> sManager)
        {
            userManager = uManager;
            signInManager = sManager;
        }

        //-------------signup-------------
        RegisterViewModel vm = new RegisterViewModel();

        [HttpGet]
        public IActionResult Register()
        {
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    Gender = model.Gender
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
            return View(vm);
        }

        //------login-----------
        //[Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            Console.WriteLine("login----");
            return View();
        }

        //[Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("vaalid");

                var result = await
                signInManager.PasswordSignInAsync(model.Username,
                                              model.Password, false, false);
                if (result.Succeeded)
                {
                    Console.WriteLine("succeed");

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        Console.WriteLine(returnUrl);
                        return RedirectToAction("privacy", "Home");
                        //return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Username or Password");
            }
            return View(model);
        }

        //------logOut---------------
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

    }
}
