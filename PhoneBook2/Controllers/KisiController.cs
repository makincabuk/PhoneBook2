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
            return View();
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Kisi xkisi)
        {
            Guid xUuid = Guid.NewGuid();
            xkisi.UUID = xUuid.ToString();

            db.Kisiler.Add(xkisi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}