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
            ViewBag.ScoreList = (from S in Db.Users orderby S.Score descending select S.Score).ToList();
			return View();
		}

	}
}