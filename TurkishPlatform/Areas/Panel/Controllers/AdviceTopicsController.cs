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
    public class AdviceTopicsController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/AdviceTopics
        public ActionResult Index()
        {
            var adviceTopics = db.AdviceTopics.Include(a => a.Advice);
            return View(adviceTopics.ToList());
        }

        // GET: Panel/AdviceTopics/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviceTopic adviceTopic = db.AdviceTopics.Find(id);
            if (adviceTopic == null)
            {
                return HttpNotFound();
            }
            return View(adviceTopic);
        }

        // GET: Panel/AdviceTopics/Create
        public ActionResult Create()
        {
            ViewBag.AdviceId = new SelectList(db.Advices, "AdviceId", "Title");
            return View();
        }

        // POST: Panel/AdviceTopics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,AdviceId")] AdviceTopic adviceTopic)
        {
            if (ModelState.IsValid)
            {
                db.AdviceTopics.Add(adviceTopic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdviceId = new SelectList(db.Advices, "AdviceId", "Title", adviceTopic.AdviceId);
            return View(adviceTopic);
        }

        // GET: Panel/AdviceTopics/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviceTopic adviceTopic = db.AdviceTopics.Find(id);
            if (adviceTopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdviceId = new SelectList(db.Advices, "AdviceId", "Title", adviceTopic.AdviceId);
            return View(adviceTopic);
        }

        // POST: Panel/AdviceTopics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,AdviceId")] AdviceTopic adviceTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adviceTopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdviceId = new SelectList(db.Advices, "AdviceId", "Title", adviceTopic.AdviceId);
            return View(adviceTopic);
        }

        // GET: Panel/AdviceTopics/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviceTopic adviceTopic = db.AdviceTopics.Find(id);
            if (adviceTopic == null)
            {
                return HttpNotFound();
            }
            return View(adviceTopic);
        }

        // POST: Panel/AdviceTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdviceTopic adviceTopic = db.AdviceTopics.Find(id);
            db.AdviceTopics.Remove(adviceTopic);
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
