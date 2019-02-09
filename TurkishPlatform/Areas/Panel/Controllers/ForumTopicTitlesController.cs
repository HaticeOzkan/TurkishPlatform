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
    public class ForumTopicTitlesController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/ForumTopicTitles
        public ActionResult Index()
        {
            var forumTopicTitles = db.ForumTopicTitles.Include(f => f.CommentCategory);
            return View(forumTopicTitles.ToList());
        }

        // GET: Panel/ForumTopicTitles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumTopicTitle forumTopicTitle = db.ForumTopicTitles.Find(id);
            if (forumTopicTitle == null)
            {
                return HttpNotFound();
            }
            return View(forumTopicTitle);
        }

        // GET: Panel/ForumTopicTitles/Create
        public ActionResult Create()
        {
            ViewBag.CommentCategoryId = new SelectList(db.ForumCommentCategories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Panel/ForumTopicTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TitleId,Text,CommentCategoryId")] ForumTopicTitle forumTopicTitle)
        {
            if (ModelState.IsValid)
            {
                db.ForumTopicTitles.Add(forumTopicTitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommentCategoryId = new SelectList(db.ForumCommentCategories, "CategoryId", "CategoryName", forumTopicTitle.CommentCategoryId);
            return View(forumTopicTitle);
        }

        // GET: Panel/ForumTopicTitles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumTopicTitle forumTopicTitle = db.ForumTopicTitles.Find(id);
            if (forumTopicTitle == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentCategoryId = new SelectList(db.ForumCommentCategories, "CategoryId", "CategoryName", forumTopicTitle.CommentCategoryId);
            return View(forumTopicTitle);
        }

        // POST: Panel/ForumTopicTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TitleId,Text,CommentCategoryId")] ForumTopicTitle forumTopicTitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumTopicTitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommentCategoryId = new SelectList(db.ForumCommentCategories, "CategoryId", "CategoryName", forumTopicTitle.CommentCategoryId);
            return View(forumTopicTitle);
        }

        // GET: Panel/ForumTopicTitles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumTopicTitle forumTopicTitle = db.ForumTopicTitles.Find(id);
            if (forumTopicTitle == null)
            {
                return HttpNotFound();
            }
            return View(forumTopicTitle);
        }

        // POST: Panel/ForumTopicTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumTopicTitle forumTopicTitle = db.ForumTopicTitles.Find(id);
            db.ForumTopicTitles.Remove(forumTopicTitle);
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
