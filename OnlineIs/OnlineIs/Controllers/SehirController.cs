using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;

namespace OnlineIs.Controllers
{
    public class SehirController : Controller
    {
        Model1 m = new Model1();
        // GET: Sehir
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<SEHIR> s = m.SEHIR.ToList();
            return View(s);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SehirEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SehirEkle(SEHIR s)
        {
            m.SEHIR.Add(s);
            m.SaveChanges();
            return RedirectToAction("Index", "Sehir");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SehirSil()
        {
            return View();
        }
        [HttpPost]
        public void SehirSil(int id)
        {
            SEHIR s = m.SEHIR.FirstOrDefault(x => x.sehirID == id);
            m.SEHIR.Remove(s);
            m.SaveChanges();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Guncelle()
        {
            return View();
        }
        [HttpPost]
        public string Guncelle(int id, string ad)
        {
            SEHIR s = m.SEHIR.FirstOrDefault(x => x.sehirID == id);
            s.sehirADI = ad;
            m.SaveChanges();
            return "guncellendi";

        }
    }
}