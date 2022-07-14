using Lec_16_JQuery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lec_16_JQuery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public PartialViewResult PartialViewMethod()
        {
            List<Product> list = new List<Product>();
            Product product = new Product();
            product.Id = 1;
            product.Name = "Moile";
            list.Add(product);
            list.Add(product);


            return PartialView("_pv1",list);
        }

        public IActionResult Index()
        {
            return View();
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