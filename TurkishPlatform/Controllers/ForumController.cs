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
            if (Session["CountryId"] == null)
            ViewBag.Categories = Db.ForumCommentCategories.Where(x => x.CountryId == 2);
            else
                ViewBag.Categories = Db.ForumCommentCategories.Where(x => x.CountryId == (int)Session["CountryId"]);
            int? Start = 0;
            return View(Start);
            //rootcomficd ebelli bir düzen var sonunda 'id' olarak ismi dogru yazarsan / dan sonra ? yazıp işte ismini yazmana gerek kalmaz ../../id=.. de ordan id diye karşıla ama başka bir isim kullanaksan ../..?x=y diye bu sefer kontrollersa x diyebilirsin id yerine  
        }
    
        public ActionResult TopicTitle(int id)
        {
            ViewBag.TopicTitleList = Db.ForumTopicTitles.Where(x => x.CommentCategoryId == id).ToList();
            
            return View();
        }
        public ActionResult CommentTopic(int id)//Soruları getireceğim
        {
            ViewBag.CommentTitle = Db.ForumCommentTopics.Where(x => x.ForumTopicTitleId ==id).ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Comment(int id)
        {
            ViewBag.Comment = Db.ForumComments.Where(x => x.CommentTopicId == id).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Comment(string Content, int id)
        {
            ViewBag.Comment = Db.ForumComments.Where(x => x.CommentTopicId == id).ToList();
            ForumComment NewComment = new ForumComment();
            NewComment.ByUser.UserId =(int) Session["EnterID"];
            NewComment.Content = Content;
            NewComment.CommentTopicId = id;
           
            return View();
        }


    }
}