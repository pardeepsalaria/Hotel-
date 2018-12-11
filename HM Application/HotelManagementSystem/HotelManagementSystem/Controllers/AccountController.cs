using HMS.BAL;
using HMS.BAL.Models;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [CustomAuthenticationFilter]
        public ActionResult LogOff()
        {
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (UserService.CheckUser(model.Email, model.Password))
            {
                Session["LoggedInUser"] = model.Email;
                string userRole = UserService.GetUserRoleByUserName(model.Email);
                Session["UserRole"] = userRole;

                if (userRole == "Admin")
                {
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Booking");
                }


            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials!");
            }
           
            return View(model);
        }

       
    }
}