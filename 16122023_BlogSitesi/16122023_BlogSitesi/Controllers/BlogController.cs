using _16122023_BlogSitesi.Entities;
using _16122023_BlogSitesi.Enum;
using _16122023_BlogSitesi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace _16122023_BlogSitesi.Controllers
{
    public class BlogController : Controller
    {
        BlogDBContext db = new BlogDBContext();
        // GET: Blog
        public ActionResult Index()
        {
            var bloglar = db.Bloglar.Where(x => !x.Silindi);
            return View(bloglar.ToList());
        }

       public ActionResult Ekle()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler.Where(x => !x.Silindi), "Id", "Ad");

            return View(new Blog());
        }

        [HttpPost]
        public ActionResult Ekle(Blog blog)
        {
            blog.Tarih = DateTime.Now;
            blog.Silindi = false;
            db.Bloglar.Add(blog);
            try
            {
                db.SaveChanges();
                TempData["Mesaj"] = Alert.Get(blog.Baslik+" Blogu başarı ile eklenmiştir",AlertEnum.success);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Mesaj"] = Alert.Get("Kayıt İşlemi Sırasında Bir Hata Meydana Geldi", AlertEnum.danger);
            }
            return View();
        }


        public ActionResult Duzenle(int id)
        {
            if (id==0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler.Where(x => !x.Silindi), "Id", "Ad");
            var blog = db.Bloglar.Find(id);
            if (blog==null)
            {
                return HttpNotFound();
            }

            return View(blog);
        }

        [HttpPost]
        public ActionResult Duzenle(Blog blog)
        {
            var duzenle=db.Bloglar.Find(blog.Id);

            duzenle.Baslik= blog.Baslik;
            duzenle.Icerik=blog.Icerik;
            duzenle.AnahtarKelime=blog.AnahtarKelime;
            duzenle.KategoriId=blog.KategoriId;
            duzenle.Durum=blog.Durum;

            try
            {
                db.SaveChanges();
                TempData["Mesaj"] = Alert.Get(" Güncelleme İşlemi başarı ile Gerçekleşmiştir", AlertEnum.success);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Mesaj"] = Alert.Get("Güncelleme İşlemi Sırasında Bir Hata Meydana Geldi", AlertEnum.danger);
            }

            return View();
        }


        public ActionResult Detay(int id) 
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        public ActionResult Sil(int id)
        {
            var blog = db.Bloglar.Find(id);
            blog.Silindi = true;
            try
            {
                db.SaveChanges();
                TempData["Mesaj"] = Alert.Get(blog.Baslik + " Blog u başarılı ile Silinmiştir", AlertEnum.success);
            }
            catch (Exception)
            {
                TempData["Mesaj"] = Alert.Get("Silme İşlemi Sırasında Bir Hata Meydana Geldi", AlertEnum.danger);
            }
            return RedirectToAction("Index");
        }
    }
}