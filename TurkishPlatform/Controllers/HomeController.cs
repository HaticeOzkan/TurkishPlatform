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
            Session["TopFive"] = ScoreViewListFill();
            Session["CountryList"] = CountryViewListFill();
            return View();
		}

        private List<CountryViewModel> CountryViewListFill()
        {//ülkeleri seçenilmeleri için ülkeleri Layoutta combobax şeklinde getirmem için name ve id lerine ihtiyaxım  vardı bende viewmodel oluşturdum
            List<CountryViewModel> countryViewModels = new List<CountryViewModel>();
            var List = (from C in Db.Countries select new { C.CountryName, C.CountryId }).ToList();
            foreach (var item in List)
            {
                CountryViewModel NewView = new CountryViewModel();
                NewView.CountryName = item.CountryName;
                NewView.CountryID = item.CountryId;
                countryViewModels.Add(NewView);
            }
            return countryViewModels;
        }

        public ActionResult Logout()
        {//çıkıs yaparken session bilgilerimi sildim
            Session.Abandon();
            Session.Clear();
            
            return RedirectToAction("Index");
        }
        private List<ScoreViewModel> ScoreViewListFill()
        {//score lara layout da göstermek için viewmodel oluşturdum
            List<ScoreViewModel> scoreViewModels = new List<ScoreViewModel>();
            var List = (from S in Db.Users where S.Score != 0 orderby S.Score descending select new { S.Score, S.NameSurname, S.ImageURL, S.UserId, S.CountryNo }).Take(5).ToList();
            foreach (var item in List)
            {
                ScoreViewModel NewScore = new ScoreViewModel();
                NewScore.CountryNo = item.CountryNo;
                NewScore.ImageURL = item.ImageURL;
                NewScore.NameSurname = item.NameSurname;
                NewScore.Score = item.Score;
                NewScore.UserID = item.UserId;

                scoreViewModels.Add(NewScore);
            }
            return scoreViewModels;
        }

    }
}