﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{
    public class ProfileController : Controller
    {
        PlatformContext Db = new PlatformContext();
        // GET: Panel/Profile
       
        public ActionResult Index(int? id,int? PersonID)
        {
            User User = Db.Users.Find(id);
            if (PersonID != null)
            {
                User User2 = Db.Users.Find(PersonID);
                //User User = Db.Users.Find(PersonID);
                User2.Score = User2.Score + 1;
                Db.Entry(User2).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CountryName = (Db.Countries.Where(x => x.CountryId == User.CountryNo).Select(x => x.CountryName)).FirstOrDefault();
            return View(User);
        }
       
    }
}