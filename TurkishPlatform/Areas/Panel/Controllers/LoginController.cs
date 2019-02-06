using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace TurkishPlatform.Areas.Panel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Panel/Login
        public ActionResult Index(string UserName,string Password)
        {
            bool IsTrue = true;
            ViewBag.Message = "Sorry. Your password was incorrect. Please double-check your password.";
            if (UserName == "Admin" && Password == "32078")
            {
                return RedirectToAction("Index", "Countries");
            }
            else
                IsTrue = false;
            return View(IsTrue);
        }
      
        public ActionResult ForgotPassword(string TextEmail)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("Ornek@gmail.com");

            ePosta.To.Add(TextEmail);
            ePosta.Subject = "TurkishPlatform Renewal Password";
            ePosta.Body = "<a href="+"'"+"/ Panel / Login / RenewalPassword"+"'"+">Renewal Password</a>";

            SmtpClient smtp = new SmtpClient();
            #region HesapBilgileri
            smtp.Credentials = new System.Net.NetworkCredential("ourturkishplatform@gmail.com", "3d1sWissen");
            #endregion
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Send(ePosta);
            //Girilen email alınacak bu email e mail gönderilcek mailde şifre yenileme linki olacak onu basınca şifre yenileme sayfası gelecek
            return View();
        }
        //şifre yenileme sayfasına yönlendirilecek
        public ActionResult RenewalPassword()
        {

            return View();
        }
    }
}