using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Areas.Panel.Controllers
{
    public class ForumCommentsController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/ForumComments
        public ActionResult Index()
        {
            var forumComments = db.ForumComments.Include(f => f.ByUser).Include(f => f.CommentTopic);
            return View(forumComments.ToList());
        }

        // GET: Panel/ForumComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumComment forumComment = db.ForumComments.Find(id);
            if (forumComment == null)
            {
                return HttpNotFound();
            }
            return View(forumComment);
        }

        // GET: Panel/ForumComments/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname");
            ViewBag.CommentTopicId = new SelectList(db.ForumCommentTopics, "TopicId", "TopicTitle");
            return View();
        }

        // POST: Panel/ForumComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Content,UserId,CommentTopicId,Permission")] ForumComment forumComment)
        {
            if (ModelState.IsValid)
            {
                db.ForumComments.Add(forumComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname", forumComment.UserId);
            ViewBag.CommentTopicId = new SelectList(db.ForumCommentTopics, "TopicId", "TopicTitle", forumComment.CommentTopicId);
            return View(forumComment);
        }

        // GET: Panel/ForumComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumComment forumComment = db.ForumComments.Find(id);
            if (forumComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname", forumComment.UserId);
            ViewBag.CommentTopicId = new SelectList(db.ForumCommentTopics, "TopicId", "TopicTitle", forumComment.CommentTopicId);
            return View(forumComment);
        }

        // POST: Panel/ForumComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Content,UserId,CommentTopicId,Permission")] ForumComment forumComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameSurname", forumComment.UserId);
            ViewBag.CommentTopicId = new SelectList(db.ForumCommentTopics, "TopicId", "TopicTitle", forumComment.CommentTopicId);
            return View(forumComment);
        }

        // GET: Panel/ForumComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumComment forumComment = db.ForumComments.Find(id);
            if (forumComment == null)
            {
                return HttpNotFound();
            }
            return View(forumComment);
        }

        // POST: Panel/ForumComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumComment forumComment = db.ForumComments.Find(id);
            db.ForumComments.Remove(forumComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
