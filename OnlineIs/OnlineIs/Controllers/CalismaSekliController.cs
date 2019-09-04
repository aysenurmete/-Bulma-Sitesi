using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;

namespace OnlineIs.Controllers
{
    public class CalismaSekliController : Controller
    {
        Model1 m = new Model1();
        // GET: CalismaSekli
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<CALISMASEKLI> c = m.CALISMASEKLI.ToList();
            return View(c);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CalismaSekliEkle()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CalismaSekliEkle(CALISMASEKLI c)
        {
            m.CALISMASEKLI.Add(c);
            m.SaveChanges();
            return RedirectToAction("Index","CalismaSekli");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CalismaSekliSil()
        {

            return View();
        }
        [HttpPost]
        public void CalismaSekliSil(int id)
        {
            CALISMASEKLI k = m.CALISMASEKLI.FirstOrDefault(x => x.calismaID == id);
            m.CALISMASEKLI.Remove(k);
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
            CALISMASEKLI c = m.CALISMASEKLI.FirstOrDefault(x => x.calismaID == id);
            c.calismaADI = ad;
            m.SaveChanges();
            return "guncellendi";

        }
    }
}