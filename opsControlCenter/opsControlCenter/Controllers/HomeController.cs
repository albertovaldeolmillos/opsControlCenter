using opsControlCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace opsControlCenter.Controllers
{
    public class HomeController : Controller
    {
        [MyAuthorize]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ViewData["USR_LOGIN"] = User.Identity.Name;

            return View();
        }
    }
}
