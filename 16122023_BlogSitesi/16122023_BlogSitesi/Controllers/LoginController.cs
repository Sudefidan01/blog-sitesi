using _16122023_BlogSitesi.Entities;
using _16122023_BlogSitesi.Enum;
using _16122023_BlogSitesi.Extensions;
using _16122023_BlogSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _16122023_BlogSitesi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel login)
        {
            BlogDBContext db= new BlogDBContext();
            var kullanici = db.Adminler.FirstOrDefault(x => x.KullaniciAdi == login.KullaniciAdi && x.Parola==login.Parola);
            if(kullanici ==null)
            {
                ViewBag.Mesaj = Alert.Get("Kullanıcı adı veya parola hatalı",AlertEnum.danger);
            }
            else
            {
                Session["Kullanici"] = kullanici;
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public ActionResult Cikis()
        {
            Session.Remove("Kullanici");
            return RedirectToAction("Index");
        }

        
    }
}