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
            Session["TopFive"] = Repository.ScoreViewListFill();

            if (Session["CountryId"] == null && (int)Session["ChooseCountry"] == 0)
                ViewBag.Topics = db.AdviceTopics.Where(x => x.CountryId == 4).ToList();

            else if ((int)Session["ChooseCountry"] != 0)
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


        public ActionResult Contents(int id)
        {
            ViewBag.Advice = db.Advices.Find(id);
            return View();
        }
    }
}