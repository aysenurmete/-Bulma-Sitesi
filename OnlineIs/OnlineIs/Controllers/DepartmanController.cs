using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;

namespace OnlineIs.Controllers
{
    public class DepartmanController : Controller
    {
        Model1 m = new Model1();
        // GET: Departman
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<DEPARTMAN> d = m.DEPARTMAN.ToList();
            return View(d);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(DEPARTMAN d)
        {
            m.DEPARTMAN.Add(d);
            m.SaveChanges();
            return RedirectToAction("Index", "Departman");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DepartmanSil()
        {
            return View();
        }
        [HttpPost]
        public void DepartmanSil(int id)
        {
            DEPARTMAN d = m.DEPARTMAN.FirstOrDefault(x => x.departmanID == id);
            m.DEPARTMAN.Remove(d);
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
            DEPARTMAN d = m.DEPARTMAN.FirstOrDefault(x => x.departmanID == id);
            d.departmanADI = ad;
            m.SaveChanges();
            return "guncellendi";

        }
    }
}