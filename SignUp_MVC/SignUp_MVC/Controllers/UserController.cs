using Microsoft.AspNetCore.Mvc;
using SignUp_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUp_MVC.Controllers
{
    public class UserController :Controller
    {
        [HttpPost]
        public void Hello(UserBO user)
        {

        }

        ViewResult Login()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult SignUp(UserBO user)
        {
            string msg = string.Empty;

           /* UserBO user = new UserBO();
            user.Username = username;
            user.Password = password;
            user.Email = email;*/

            if (UserManagment.UserAlreadyExist(user))
            {
                TempData["duplicate_email"] = "This email already exists";
                return View("SignUp",msg);
            }
            else
            {
                TempData["duplicate_email"] = string.Empty;

                UserManagment.SaveLoginInfo(user);

                Console.WriteLine("hello");
                return RedirectToAction();
            }
        }
     

        [HttpGet]
        public ViewResult SignUp()
        {
            return View("Signup");
        }

      
    }
}
