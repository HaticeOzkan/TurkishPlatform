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
    public class AdminProfilsController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/AdminProfils
        public ActionResult Index()
        {
            return View(db.AdminProfils.ToList());
        }

        // GET: Panel/AdminProfils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminProfil adminProfil = db.AdminProfils.Find(id);
            if (adminProfil == null)
            {
                return HttpNotFound();
            }
            return View(adminProfil);
        }

        // GET: Panel/AdminProfils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Panel/AdminProfils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InfoID,MailAdress,Password,Name")] AdminProfil adminProfil)
        {
            if (ModelState.IsValid)
            {
                db.AdminProfils.Add(adminProfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminProfil);
        }

        // GET: Panel/AdminProfils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminProfil adminProfil = db.AdminProfils.Find(id);
            if (adminProfil == null)
            {
                return HttpNotFound();
            }
            return View(adminProfil);
        }

        // POST: Panel/AdminProfils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InfoID,MailAdress,Password,Name")] AdminProfil adminProfil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminProfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminProfil);
        }

        // GET: Panel/AdminProfils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminProfil adminProfil = db.AdminProfils.Find(id);
            if (adminProfil == null)
            {
                return HttpNotFound();
            }
            return View(adminProfil);
        }

        // POST: Panel/AdminProfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminProfil adminProfil = db.AdminProfils.Find(id);
            db.AdminProfils.Remove(adminProfil);
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
