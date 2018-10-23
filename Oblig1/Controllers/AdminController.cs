using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.AdminModel;

namespace Oblig1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin Hei all sammen
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                //if(getAdmin(login))
                Session["AdminLoggedIn"] = true;
                return RedirectToAction("AdminPanel");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AdminPanel()
        {
            return View();
        }


    }
}