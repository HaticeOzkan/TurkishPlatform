using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurkishPlatform.Areas.Panel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Panel/Login
        public ActionResult Index(string Email,string Password)
        {
            if(Email== "dalkranberna@gmail.com" && Password == "32078")
            {
                return RedirectToAction("Index", "Countries");
            }
            return View();
        }
    }
}