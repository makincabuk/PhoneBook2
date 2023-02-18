using PhoneBook2.Models.Context;
using PhoneBook2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using PhoneBook2.Models.KisiModel;

namespace PhoneBook2.Controllers
{
    public class KisiController : Controller
    {
        PhoneContext db = new PhoneContext();

        // GET: Kisi
        public ActionResult Index()
        {

            var kisiler = db.Kisiler.ToList();
            return View(kisiler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Kisi xkisi)
        {
            try
            {
                Guid xUuid = Guid.NewGuid();
                xkisi.UUID = xUuid.ToString();

                db.Kisiler.Add(xkisi);
                db.SaveChanges();
                TempData["BasariliMesaj"] = "Yeni Kişi Rehbere Başarılı Bir Şekilde Eklendi.";
            }
            catch (Exception)
            {
                TempData["BasarisizMesaj"] = "Yeni Kişi Rehbere Eklenemedi!";
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["BasarisizMesaj"] = "Güncellemek İstediğiniz Kayıt Bulunamadı!";
                return RedirectToAction("Index");
            }
            var model = new KisiGuncelleViewModel { Kisi=kisi};

            return View(model);
        }
        public ActionResult Guncelle(Kisi kisi)
        {
            var Eskikisi = db.Kisiler.Find(kisi.Id);
            if (Eskikisi==null)
            {
                TempData["BasarisizMesaj"] = "Güncellemek İstediğiniz Kayıt Bulunamadı!";
                return RedirectToAction("Index");
            }
            Eskikisi.Ad = kisi.Ad;
            Eskikisi.Soyad = kisi.Soyad;

            db.SaveChanges();
            TempData["BasariliMesaj"] = "Kişi Bilgileri Başarılı Bir Şekilde Güncellendi.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detay(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi==null)
            {
                TempData["BasarisizMesaj"] = "Kişi Bulunamadı!";
                return RedirectToAction("Index");
            }
            var model = new KisiDetayViewModel {Kisi=kisi };

            return View(model);
        }
        public ActionResult Sil(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi==null)
            {
                TempData["BasarisizMesaj"] = "Kişi Bulunamadı!";
                return RedirectToAction("Index");
            }
            db.Kisiler.Remove(kisi);
            db.SaveChanges();
            TempData["BasariliMesaj"] = "Kişi Başarılı Bir Şekilde Silindi";
            return RedirectToAction("Index");
        }
    }
}