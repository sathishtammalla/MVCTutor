using MVCTutor.Model;
using MVCTutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCTutor.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails user)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
                UserStatus status = ebl.GetUserValidity(user);
                bool IsAdmin = false;
                if (status == UserStatus.AuthenticatedAdmin)
                {
                    IsAdmin = true;
                }
                else if (status == UserStatus.AuthenticatedUser){
                    IsAdmin = false;
                    }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid UserName or Password");
                    return View("Login");
                }

                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["IsAdmin"] = IsAdmin;
                 return RedirectToAction("Index", "Employee");
                    
            }

            else
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}