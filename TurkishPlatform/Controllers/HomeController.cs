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
		public ActionResult Index()
		{
            Session["TopFive"] = ViewListFill();
            return View();
		}
        private List<ScoreViewModel> ViewListFill()
        {
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