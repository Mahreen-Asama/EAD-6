using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_Identity.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
