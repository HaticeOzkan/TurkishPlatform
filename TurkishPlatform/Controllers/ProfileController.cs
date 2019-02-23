using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{
    public class ProfileController : Controller
    {
        PlatformContext Db = new PlatformContext();
        // GET: Panel/Profile
        [HttpGet]
        public ActionResult Index(int id)
        {
            User User = Db.Users.Find(id);
            ViewBag.CountryName = (Db.Countries.Where(x => x.CountryId == User.CountryNo).Select(x => x.CountryName)).FirstOrDefault();
            return View(User);
        }
        [HttpPost]
        public ActionResult Index(int ProfilID, int ScorePuan)
        {
            User User = Db.Users.Find(ProfilID);
            User.Score = User.Score + ScorePuan;
            Db.Entry(User).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}