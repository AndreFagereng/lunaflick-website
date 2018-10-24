using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.AdminModel;

namespace PresentationLayer.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin Hei all sammen
    
        public ActionResult Login()
        {
            if (ModelState.IsValid)
            {
                //if(getAdmin(login))
                
                return RedirectToAction("AdminPanel");
            }
            else
            {
                return RedirectToAction("AdminPanel");
            }
        }

        public ActionResult AdminPanel()
        {
            return View();
        }


    }
}