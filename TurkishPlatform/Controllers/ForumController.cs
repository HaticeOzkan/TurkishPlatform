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

                x.Text,
                x.TitleId
                
            }).ToList();
            return Json(TitleList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Title(int ID)
        {
            var TopicList = Db.ForumCommentTopics.Where(x => x.ForumTopicTitleId == ID).Select(x => new {
                x.TopicTitle,
                x.TopicId }).ToList();
            return Json(TopicList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Comment(int ID)
        {
           
          
            var CommentList = Db.ForumComments.Where(x => x.CommentTopicId == ID).ToList();
            return View(CommentList);
        }
        [HttpPost]
        public ActionResult Comment(string Comment)
        {
            ForumComment Com = new ForumComment();
            Com.Content = Comment;
           //user id eklenecek
            Db.ForumComments.Add(Com);
            Db.SaveChanges();
            return RedirectToAction("Comment");
        }
      
    }
}