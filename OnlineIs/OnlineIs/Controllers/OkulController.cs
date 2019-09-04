using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;
namespace OnlineIs.Controllers
{
    public class OkulController : Controller
    {
        Model1 m = new Model1();
        // GET: Okul
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<OKUL> o = m.OKUL.ToList();
            return View(o);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult OkulEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OkulEkle(OKUL o)
        {
            m.OKUL.Add(o);
            m.SaveChanges();
            return RedirectToAction("Index", "Okul");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult OkulSil()
        {
            return View();
        }
        [HttpPost]
        public void OkulSil(int id)
        {
            OKUL o = m.OKUL.FirstOrDefault(x => x.okulID == id);
            m.OKUL.Remove(o);
            m.SaveChanges();
        }
        public ActionResult Guncelle()
        {
            return View();
        }
        [HttpPost]
        public string Guncelle(int id, string ad)
        {
            OKUL o= m.OKUL.FirstOrDefault(x => x.okulID == id);
            o.okulADI = ad;
            m.SaveChanges();
            return "guncellendi";

        }
    }
}