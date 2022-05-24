using Lec_11_LayoutSections.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lec_11_LayoutSections.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> ss = new List<string>();
            ss.Add("abc");
            ss.Add("def");
            ss.Add("hello");
            return View(ss);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}