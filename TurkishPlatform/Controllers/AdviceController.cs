using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{
    public class AdviceController : Controller
    {
        PlatformContext db = new PlatformContext();

        public ActionResult Index()
        {
            if (Session["ChooseCountry"] == null && Session["CountryId"] == null)
            {
                ViewBag.Topics = db.AdviceTopics.Where(x => x.CategoryId == 4).ToList();
            }
            else if (Session["ChooseCountry"] != null)
            {
                int IdCountry = (int)Session["ChooseCountry"];
                ViewBag.Topics = db.AdviceTopics.Where(x => x.CountryId == IdCountry).ToList();
            }
            else
            {
                int IdC = (int)Session["CountryId"];
                ViewBag.Topics = db.AdviceTopics.Where(x => x.CountryId == IdC).ToList();
            }

            return View();
            
        }

        [HttpPost]
        public ActionResult Contents(int id)
        {
            Advice adv = db.Advices.Find(id);
            return View(adv);
        }
    }
}