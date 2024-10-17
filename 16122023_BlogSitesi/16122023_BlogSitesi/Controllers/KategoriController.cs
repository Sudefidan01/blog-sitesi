using _16122023_BlogSitesi.Entities;
using _16122023_BlogSitesi.Enum;
using _16122023_BlogSitesi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _16122023_BlogSitesi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        BlogDBContext db=new BlogDBContext();
        public ActionResult Index()
        {
            var kategoriler = db.Kategoriler.Where(x => !x.Silindi);
            return View(kategoriler);
        }

        public ActionResult Ekle()
        {
            return View(new Kategori());
        }

        [HttpPost]
        public ActionResult Ekle(Kategori kategori)
        {
            kategori.Tarih = DateTime.Now;
            kategori.Silindi = false;
            db.Kategoriler.Add(kategori);
            try
            {
                db.SaveChanges();
                TempData["Mesaj"] = Alert.Get(kategori.Ad + " Kategorisi Başarı ile Eklenmiştir", AlertEnum.success);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Mesaj"] = Alert.Get(" Kayıt İşlemi esnasında Bir Hata Meydana Geldi ", AlertEnum.danger);
            }
            return View();
        }

        public ActionResult Duzenle(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            return View(kategori);

        }
        [HttpPost]
        public ActionResult Duzenle(Kategori kategori)
        {
            var duzenle = db.Kategoriler.Find(kategori.Id);

            duzenle.Ad= kategori.Ad;
            duzenle.Aciklama=kategori.Aciklama;
            duzenle.Durum= kategori.Durum;
            try
            {
                db.SaveChanges();
                TempData["Mesaj"] = Alert.Get("Güncelleme İşlemi Başarı İle Gerçekleşti", AlertEnum.success);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Mesaj"] = Alert.Get(" Güncelleme İşlemi esnasında Bir Hata Meydana Geldi ", AlertEnum.danger);
            }
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kategori=db.Kategoriler.Find(id);
            kategori.Silindi = true;
            try
            {
                db.SaveChanges();
                TempData["Mesaj"]=Alert.Get(kategori.Ad+" Kategorisi Başarı ile Silinmiştir ",AlertEnum.success);
            }
            catch (Exception)
            {
                TempData["Mesaj"] = Alert.Get(" Silme İşlemi Esnasında Bir Hata Meydana Geldi", AlertEnum.success);

            }
            return RedirectToAction("Index");
        }
    }
}