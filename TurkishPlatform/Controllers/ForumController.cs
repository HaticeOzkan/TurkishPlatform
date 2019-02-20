using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{
    public class ForumController : Controller
    {
        PlatformContext Db = new PlatformContext();
        // GET: Forum
        
        public ActionResult Index()
        {
            ViewBag.Categories = Db.ForumCommentCategories.ToList();
            int? Start = 0;
            return View(Start);
        }

        public ActionResult TopicTitle(int CountryID)
        {
            var TopicTitleList = Db.ForumTopicTitles.Where(x => x.CommentCategoryId == CountryID).ToList();
            
            return View();
        }
    }
}