using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;
namespace OnlineIs.Controllers
{
    public class SektorController : Controller
    {
        Model1 m = new Model1();
        // GET: Sektor
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<SEKTOR> s = m.SEKTOR.ToList();
            return View(s);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SektorEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SektorEkle(SEKTOR s)
        {
            m.SEKTOR.Add(s);
            m.SaveChanges();
            return RedirectToAction("Index", "Sektor");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SektorSil()
        {
            return View();
        }
        [HttpPost]
        public void SektorSil(int id)
        {
            SEKTOR s = m.SEKTOR.FirstOrDefault(x => x.sektorID == id);
            m.SEKTOR.Remove(s);
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
            SEKTOR s = m.SEKTOR.FirstOrDefault(x => x.sektorID == id);
            s.sektorADI = ad;
            m.SaveChanges();
            return "guncellendi";

        }
    }
}