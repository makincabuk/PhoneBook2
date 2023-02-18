using PhoneBook2.Models.Context;
using PhoneBook2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

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
        public ActionResult Guncelle(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["BasarisizMesaj"] = "Güncellemek İstediğiniz Kayıt Bulunamadı!";
                return RedirectToAction("Index");
            }
            return View(kisi);

        }
    }
}