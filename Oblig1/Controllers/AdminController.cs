using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin Hei all sammen
        public ActionResult AdminLogin()
        {
            return View();
        }
    }
}