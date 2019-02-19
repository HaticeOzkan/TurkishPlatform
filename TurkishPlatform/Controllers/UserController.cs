using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Controllers
{

    // GET: User
    public class UserController : Controller
    {
       //birden çok admin olabilir
        PlatformContext Db = new PlatformContext();
        // GET: Panel/Login
        //Burası yöneticinin Giriş yaptıgı bölüm aşağıda şifremi unutuum kısmı var 

        [HttpPost]
        [ValidateAntiForgeryToken]//Güvenlik için bunu koymazsak postta javascript atakları yapıp verilerimize ulaşılabilir bunu koydugumuz çin view kısmına formdan sonra  @Html.AntiForgeryToken() koymalıyız
        public ActionResult Index(string Email, string Password)
        {
            ViewBag.Countries = Db.Countries.ToList();
            bool? IsTrue = false;
            User User = new User();
            List<User> ListProfile = Db.Users.ToList();
            foreach (var item in ListProfile)
            {
                if (Email == item.Email)
                {
                    if (Password == item.Password)
                    {
                        IsTrue = true;
                        Session["CountryId"] = item.CountryNo;                      
                        Session["EnterID"] = item.UserId;
                        Session["ImageURL"] = "Content/Login/" + Session["EnterID"];
                        Session["Email"] = item.Email;
                        Session["Gender"] = item.Gender;
                        Session["NameSurname"] = item.NameSurname;                       
                        return RedirectToAction("Index", "Home");
                        
                    }
                }
            }
            ViewBag.Message = "Sorry. Your password or name was incorrect. Please double-check your password.";
            return View(IsTrue);
        }
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Countries = Db.Countries.ToList();

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
        public JsonResult AddImage(HttpPostedFileBase UserImage)//buraya alırken file[] dizi olması sıkıntı oldu recipe image yaptık
        {
            if (UserImage != null && UserImage.ContentLength != 0)
            {
                var path = Server.MapPath("/Content/Login/");
                UserImage.SaveAs(path + Session["UserID"]+".jpg");
                FileList flist = new FileList();
                var files = flist.files;
                File f = new File();
                f.name = UserImage.FileName;
                f.url = "Content/Login/" + Session["UserID"]+".jpg";//KAYDOLUCAGI KISIM
                Session["ImageURL"] = f.url;
                f.thumbnailUrl = f.url;
                files.Add(f);
                return Json(files);
            }
            return Json(false);
        }

        public JsonResult Registery(User user)
        {         

            if (ModelState.IsValid)
            {              
                Db.Users.Add(user);               
                Db.SaveChanges();
                Session["UserID"] = user.UserId;
            
                
                RedirectToAction("Index");
                return Json(true);
            }
            return Json(false);
        }

    
    }
}
