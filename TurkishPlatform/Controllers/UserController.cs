using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public class LoginController : Controller
        {
            User User = new User();//birden çok admin olabilir
            PlatformContext Db = new PlatformContext();
            // GET: Panel/Login
            //Burası yöneticinin Giriş yaptıgı bölüm aşağıda şifremi unutuum kısmı var 
            
            [HttpPost]
            [ValidateAntiForgeryToken]//Güvenlik için bunu koymazsak postta javascript atakları yapıp verilerimize ulaşılabilir bunu koydugumuz çin view kısmına formdan sonra  @Html.AntiForgeryToken() koymalıyız
            public ActionResult Index(string UserName, string Password)
            {
               
                bool? IsTrue = true;

                List<User> ListProfile = Db.Users.ToList();
                foreach (var item in ListProfile)
                {
                    if (UserName == item.NameSurname)
                    {
                       User.NameSurname = item.NameSurname;
                       User.Password = item.Password;
                        User.Email = item.Email;

                    }
                }
                ViewBag.Message = "Sorry. Your password or name was incorrect. Please double-check your password.";
                if (UserName == User.NameSurname && Password == User.Password)
                {
                    return RedirectToAction("Index");

                }
                else
                    IsTrue = false;//eger şifresini yanlış girmişse
                return View(IsTrue);
            }
            [HttpGet]
            public ActionResult Register()
            {
                ViewBag.Contries = Db.Countries.ToList();
                return View();
            }
            [HttpPost]
            public ActionResult Register(User user)
            {
                User NewUser = new User();
                if (ModelState.IsValid)
                {
                   NewUser = user;
                 
                }
                ViewBag.Contries = Db.Countries.ToList();
                return View();
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
                ePosta.Body = "http://localhost:59574/User/RenewalPassword?Mail=" + TextEmail;

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
                    User Account = Db.Users.Where(x => x.Email == Mail).FirstOrDefault(); 
                    Account.Password = NewPassword;
                    Db.Entry(Account).State = System.Data.Entity.EntityState.Modified;
                    Db.SaveChanges();
                    Control = true;
                    RedirectToAction("Index");
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
}