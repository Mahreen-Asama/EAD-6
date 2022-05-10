using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignUp_MVC.Models;
using SignUp_MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignUp_MVC.Controllers
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
            /* 1 --- First Method to pass data to view
             
            List<UserBO> users = UserManagment.GetAllUsers();
            List<Address> addresses = UserManagment.GetAllAddresses();

            List<UserInfo> infos=new List<UserInfo>();

            for (int i= 0; i<users.Count; i++)
            { 
                UserInfo info = new UserInfo();
                info.UserIds = users[i];
                info.UserAddress = addresses[i];
                infos.Add(info);
            }

            return View(infos);*/

            // 2- Second way to collect data for view

            //ViewBag.Title = "HomeTable";
            ViewBag.Description = "heelo this is view bag";

            ViewData["string1"] = "I am string1";

            UserBO ub=new UserBO();
            Address ad= new Address();

            return View(ub, ad);
            /*return View(UserManagment.GetAllUsersInfo());*/

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
