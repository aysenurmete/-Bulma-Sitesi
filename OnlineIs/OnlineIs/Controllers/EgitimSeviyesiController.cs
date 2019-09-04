using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;

namespace OnlineIs.Controllers
{
    public class EgitimSeviyesiController : Controller
    {
        Model1 m = new Model1();
        // GET: EgitimSeviyesi
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<EGITIMSEVIYESI> e = m.EGITIMSEVIYESI.ToList();
            return View(e);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EgitimSeviyesiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimSeviyesiEkle(EGITIMSEVIYESI e)
        {
            m.EGITIMSEVIYESI.Add(e);
            m.SaveChanges();
            return RedirectToAction("Index", "EgitimSeviyesi");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EgitimSeviyesiSil()
        {
            return View();
        }
        [HttpPost]
        public void EgitimSeviyesiSil(int id)
        {
            EGITIMSEVIYESI e = m.EGITIMSEVIYESI.FirstOrDefault(x => x.egitimseviyeID == id);
            m.EGITIMSEVIYESI.Remove(e);
            m.SaveChanges();
            // return RedirectToAction("index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Guncelle()
        {
            return View();
        }
        [HttpPost]
        public string Guncelle(int id, string ad)
        {
            EGITIMSEVIYESI e = m.EGITIMSEVIYESI.FirstOrDefault(x => x.egitimseviyeID == id);
            e.egitimseviyeADI = ad;
            m.SaveChanges();
            return "guncellendi";

        }
    }
}