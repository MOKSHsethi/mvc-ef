using Assesment_MVC_EF.Context;
using Assesment_MVC_EF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System;

namespace Assesment_MVC_EF.Controllers
{
    public class LoginController : Controller
    {

        UserInterface _repo;
        public LoginController(UserInterface repo)
        {
            _repo = repo;
        }



        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel obj)
        {


           User user = _repo.Exists(obj.Email, obj.Password);
            if (user != null)
            {


                if ((int)user.UserRole == 0)
                {

                    return RedirectToAction("AdminDashboard","Home");
                }
                else if ((int)user.UserRole == 1)
                {
                    return RedirectToAction("Managerdashboard", "Home");
                }
                else if ((int)user.UserRole == 2)
                {

                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            else
                ViewBag.msg = "Not a valid user";
              
            return View();
        }
    }
}
        
        
    








            //[HttpPost]
            //public IActionResult Login(LoginViewModel model)
            //{
            //    var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);



    //    if (user == null)
    //    {
    //        ViewBag.ErrorMessage = "Invalid Username or password.";
    //        return View();
    //    }
    //switch ((int)user.UserRole)
    //{
    //    case 0:
    //        return RedirectToAction("AdminDashboard", "Home"); break;
    //    case 1:
    //        return RedirectToAction("ManagerDashboard", "Home"); break;
    //    case 2:
    //        return RedirectToAction("EmployeeDashboard", "Home"); break;
    //    default:
    //        return RedirectToAction("Index", "Home");
    //}




    // Perform any necessary authentication/authorization checks here



    // Redirect to appropriate action based on user role
    //switch (user.Role)
    //{
    //    case UserRole.Admin:
    //        return RedirectToAction("AdminDashboard", "Home");
    //    case UserRole.Manager:
    //        return RedirectToAction("ManagerDashboard", "Home");
    //    case UserRole.Employee:
    //        return RedirectToAction("EmployeeDashboard", "Home");
    //    default:
    //        return RedirectToAction("Index", "Home");
    //}
        
