using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{
	public class HomeController : Controller
	{
       
        PlatformContext Db = new PlatformContext();
       
        public ActionResult Index(string CombxCountry)
		{//anasayfada ilk ulke ülke comboboxsını dolduruyorum ülke seçimini ve en çok yardım eden 5 kişiyi alıyorum
            Session["ChooseCountry"] =Convert.ToInt32(CombxCountry);
            Session["TopFive"] = Repository.ScoreViewListFill();
            Session["CountryList"] = Repository.CountryViewListFill();
            return View();
		}

       

        public ActionResult Logout()
        {//çıkıs yaparken session bilgilerimi sildim
            Session.Abandon();
            Session.Clear();
            
            return RedirectToAction("Index");
        }
     

    }
}