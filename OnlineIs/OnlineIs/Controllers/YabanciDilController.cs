using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;
namespace OnlineIs.Controllers
{
    public class YabanciDilController : Controller
    {
        Model1 m = new Model1();
        // GET: YabanciDil
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<YABANCIDIL> y = m.YABANCIDIL.ToList();
            return View(y);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult YabancıDilEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YabancıDilEkle(YABANCIDIL y)
        {
            m.YABANCIDIL.Add(y);
            m.SaveChanges();
            return RedirectToAction("Index", "YabanciDil");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult YabanciDilSil()
        {
            return View();
        }
        [HttpPost]
        public void YabanciDilSil(int id)
        {
            YABANCIDIL y = m.YABANCIDIL.FirstOrDefault(x => x.yabancidilID == id);
            m.YABANCIDIL.Remove(y);
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
            YABANCIDIL y = m.YABANCIDIL.FirstOrDefault(x => x.yabancidilID == id);
            y.yabancidilADI = ad;
            m.SaveChanges();
            return "guncellendi";

        }
    }
}