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
            Session["TopFive"] = Repository.ScoreViewListFill();
            //hiç ülke seçilmemişse ve giriş yapılmamışsa 3 id li ülkeyi getirir
            if (Session["CountryId"] == null && (int)Session["ChooseCountry"] == 0)
            {
                ViewBag.Categories = Db.ForumCommentCategories.Where(x => x.CountryId == 2).ToList();
            }//eğer seçim yapılmışsa seçilen ülkeyi getirir
            else if ((int)Session["ChooseCountry"] != 0)
            {
                int CountryID = (int)Session["ChooseCountry"];
                ViewBag.Categories = Db.ForumCommentCategories.Where(x => x.CountryId == CountryID).ToList();
            }
            else //seçim ve giriş yapılmışsa
            {
                int ID = (int)Session["CountryId"];
                ViewBag.Categories = Db.ForumCommentCategories.Where(x => x.CountryId == ID).ToList();
            }

            return View();
            //rootcomficd ebelli bir düzen var sonunda 'id' olarak ismi dogru yazarsan / dan sonra ? yazıp işte ismini yazmana gerek kalmaz ../../id=.. de ordan id diye karşıla ama başka bir isim kullanaksan ../..?x=y diye bu sefer kontrollersa x diyebilirsin id yerine  
        }

        public ActionResult TopicTitle(int id)
        {

            ViewBag.TopicTitleList = Db.ForumTopicTitles.Where(x => x.CommentCategoryId == id).ToList();

            return View();
        }
        public ActionResult CommentTopic(int id)//Soruları getireceğim
        {//bunun id sini tutayım ki Konu başlattıgında kullanıcı bunun altına eklensin id Topic Title id
            ViewBag.TopicTitleID = id;
            ViewBag.CommentTitle = Db.ForumCommentTopics.Where(x => x.ForumTopicTitleId == id).ToList();
            return View();
        }


        public ActionResult Comment(string Content, int id, int? DeleteID)
        {
            if (DeleteID != null)
            {
                ForumComment Comment = Db.ForumComments.Find(DeleteID);
                Db.ForumComments.Remove(Comment);
                Db.SaveChanges();
            }
            if (Content != null)
            {
                ForumComment NewComment = new ForumComment();
                int UserID = (int)Session["EnterID"];
                User ByUser = Db.Users.Find(UserID);
                NewComment.ByUser = ByUser;
                NewComment.Content = Content;
                NewComment.CommentTopic = Db.ForumCommentTopics.Find(id);
                Db.ForumComments.Add(NewComment);
                Db.SaveChanges();
            }
            ViewBag.Comment = Db.ForumComments.Where(x => x.CommentTopicId == id).ToList();
            return View();
        }

        public ActionResult StartSubject(int? id, string Content, string Title)//burda gelen id topictitle id si
        {//topic title la topic i ekleyip guncelleme yapıcam
            ForumTopicTitle TopicTitle = Db.ForumTopicTitles.Find(id);
            if (Content != null)
            {              
                //burda konu ismini yazıyor ayrıca sorusunuda soruyor hem topic oluşturuyorum hemde comment oluşturuyorum 
                ForumCommentTopic NewTopic = new ForumCommentTopic();
                NewTopic.TopicTitle = Title;
                NewTopic.ForumComments = new List<ForumComment>();
                NewTopic.ForumTopicTitle = Db.ForumTopicTitles.Find(TopicTitle.TitleId);
                Db.ForumCommentTopics.Add(NewTopic);
                Db.SaveChanges();
                ForumComment NewComment = new ForumComment();
                NewComment.Content = Content;
                int UserID = (int)Session["EnterID"];
                NewComment.ByUser = Db.Users.Find(UserID);
                int CommentTitleID = Db.ForumCommentTopics.OrderByDescending(x => x.TopicId).Take(1).Select(x => x.TopicId).FirstOrDefault();
                NewComment.CommentTopic = Db.ForumCommentTopics.Find(CommentTitleID);
                Db.ForumComments.Add(NewComment);
                Db.SaveChanges();
                return View();
            }
            return View();
        }
    }
}