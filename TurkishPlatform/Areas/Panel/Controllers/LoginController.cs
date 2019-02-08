using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Areas.Panel.Models;
using TurkishPlatform.Models;

namespace TurkishPlatform.Areas.Panel.Controllers
{
    public class LoginController : Controller
    {
        AdminView adminView = new AdminView();//birden çok admin olabilir
        PlatformContext Db = new PlatformContext();
        // GET: Panel/Login
        //Burası yöneticinin Giriş yaptıgı bölüm aşağıda şifremi unutuum kısmı var 
        [HttpPost]
        [ValidateAntiForgeryToken]//Güvenlik için bunu koymazsak postta javascript atakları yapıp verilerimize ulaşılabilir bunu koydugumuz çin view kısmına formdan sonra  @Html.AntiForgeryToken() koymalıyız
        public ActionResult Index(string UserName, string Password)
        {
            bool? IsTrue = true;

            List<AdminProfil> ListProfile = Db.AdminProfils.ToList();
            foreach (var item in ListProfile)
            {
                if (UserName == item.Name)
                {
                    adminView.Name = item.Name;
                    adminView.Password = item.Password;
                    adminView.Email = item.MailAdress;

                }
            }
            ViewBag.Message = "Sorry. Your password or name was incorrect. Please double-check your password.";
            if (UserName == adminView.Name && Password == adminView.Password)
            {
                return RedirectToAction("Index", "Countries");

            }
            else
                IsTrue = false;//eger şifresini yanlış girmişse
            return View(IsTrue);
        }
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ForgotPassword(string TextEmail)
        {

            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("Ornek@gmail.com");

            ePosta.To.Add(TextEmail);
            ePosta.Subject = "TurkishPlatform Renewal Password";
            ePosta.Body = "http://localhost:59574/Panel/Login/RenewalPassword?Mail=" + TextEmail;

            SmtpClient smtp = new SmtpClient();
            #region HesapBilgileri
            smtp.Credentials = new System.Net.NetworkCredential("ourturkishplatform@gmail.com", "3d1sWissen");
            #endregion
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Send(ePosta);

            //Girilen email alınacak bu email e mail gönderilcek mailde şifre yenileme linki olacak onu basınca şifre yenileme sayfası gelecek
            return View(true);

        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        //şifre yenileme sayfasına yönlendirilecek
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RenewalPassword(string NewPassword, string NewPasswordRepeat)
        {
            bool? Control = false;
            ViewBag.ControlPassword = "Must match the previous entry";

            if (NewPassword == NewPasswordRepeat)
            {
                string Mail = Request.QueryString["Mail"];
                AdminProfil Account = Db.AdminProfils.Where(x => x.MailAdress == Mail).FirstOrDefault();
                Account.Password = NewPassword;
                Db.Entry(Account).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
                Control = true;
                RedirectToAction("RenewalPassword", "Index");
            }

            return View(Control);
        }
        [HttpGet]
        public ActionResult RenewalPassword()
        {

            return View();
        }
        //şimdi yeni bir şifre girdi onu guncellemem için kişinin id si lazım ki o kişiyi getireyim ajax kullandım

    }

}
