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
            ViewBag.CategoryList = Db.ForumCommentCategories.ToList();
           
            return View();
        }
        public JsonResult Topics(int ID)
        {
          var TitleList= Db.ForumTopicTitles.Where(x => x.CommentCategoryId == ID).Select(x => new {

                x.Text
            }).ToList();
            return Json(TitleList);
        }
    }
}