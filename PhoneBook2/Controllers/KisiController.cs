﻿using PhoneBook2.Models.Context;
using PhoneBook2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using PhoneBook2.Models.KisiModel;
using PhoneBook2.Models.IletisimModel;

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
        [HttpGet]
        public ActionResult IletisimEkle(int id)
        {
            var kisi = db.Kisiler.Find(id);
            var telefon = db.Telefonlar.ToList();
            var eposta = db.Epostalar.ToList();
            var konum = db.Konumlar.ToList();
            if (kisi==null/*||telefon==null||eposta==null||konum==null*/)
            {
                TempData["BasarisizMesaj"] = "İletişim Bilgisi Eklemek İstediğiniz Kayıt Bulunamadı!";
                return RedirectToAction("Index");
            }
            var model = new IletisimEkleViewModel { Kisi = kisi,TelefonL=telefon,EpostaL=eposta,KonumL=konum };
            return View(model);
        }

        [HttpPost]
        public ActionResult TelefonEkle(IletisimEkleViewModel x)
        {
            try
            {
                x.Telefon.Uid = x.Kisi.Id;
                x.Telefon.UUID = x.Kisi.UUID;
                db.Telefonlar.Add(x.Telefon);
                db.SaveChanges();
                TempData["BasariliMesaj"] = "Telefon Numarası Baraşılı Bir Şekilde Eklendi.";
            }
            catch (Exception)
            {
                TempData["BasarisizMesaj"] = "Telefon Numarası Eklenemedi!";
            }
            return RedirectToAction("IletisimEkle/"+x.Kisi.Id);
        }

        [HttpPost]
        public ActionResult EpostaEkle(IletisimEkleViewModel x)
        {
            try
            {
                x.Eposta.Uid = x.Kisi.Id;
                x.Eposta.UUID = x.Kisi.UUID;
                db.Epostalar.Add(x.Eposta);
                db.SaveChanges();
                TempData["BasariliMesaj"] = "Eposta Adresi Baraşılı Bir Şekilde Eklendi.";
            }
            catch (Exception)
            {
                TempData["BasarisizMesaj"] = "Eposta Adresi Eklenemedi!";
            }
            return RedirectToAction("IletisimEkle/" + x.Kisi.Id);
        }

        [HttpPost]
        public ActionResult KonumEkle(IletisimEkleViewModel x)
        {
            try
            {
                x.Konum.Uid = x.Kisi.Id;
                x.Konum.UUID = x.Kisi.UUID;
                db.Konumlar.Add(x.Konum);
                db.SaveChanges();
                TempData["BasariliMesaj"] = "Konum Adresi Baraşılı Bir Şekilde Eklendi.";
            }
            catch (Exception)
            {
                TempData["BasarisizMesaj"] = "Konum Adresi Eklenemedi!";
            }
            return RedirectToAction("IletisimEkle/" + x.Kisi.Id);
        }
    }
}