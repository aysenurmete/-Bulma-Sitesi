using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;
namespace OnlineIs.Controllers
{
    public class PozisyonController : Controller
    {
        Model1 m = new Model1();
        // GET: Pozisyon
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<POZISYON> p = m.POZISYON.ToList();
            return View(p);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult PozisyonEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PozisyonEkle(POZISYON p)
        {
            m.POZISYON.Add(p);
            m.SaveChanges();
            return RedirectToAction("Index", "Pozisyon");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult PozisyonSil()
        {
            return View();
        }
        [HttpPost]
        public void PozisyonSil(int id)
        {
            POZISYON p = m.POZISYON.FirstOrDefault(x => x.pozisyonID == id);
            m.POZISYON.Remove(p);
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
            POZISYON p = m.POZISYON.FirstOrDefault(x => x.pozisyonID == id);
            p.pozisyonADI = ad;
            m.SaveChanges();
            return "guncellendi";

        }
    }
}