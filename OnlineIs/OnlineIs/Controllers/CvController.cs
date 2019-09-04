using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;
namespace OnlineIs.Controllers
{
    public class CvController : Controller
    {
        Model1 m = new Model1();
        public ActionResult Index()
        {
            List<CV> ı = m.CV.ToList();
            return View(ı);
        }
        [Authorize(Roles = "Kullanıcı")]
        public ActionResult CvEkle()
        {
            List<EGITIMSEVIYESI> egitimseviyesi = m.EGITIMSEVIYESI.ToList();
            List<YABANCIDIL> yabancidil = m.YABANCIDIL.ToList();
            List<OKUL> okul = m.OKUL.ToList();

            ViewBag.egitimseviyesi = egitimseviyesi;
            ViewBag.yabancidil = yabancidil;
            ViewBag.okul = okul;
            return View();
        }

        [HttpPost]
        public ActionResult CvEkle(CV c)
        {
            //m.CV.Add(c);
            //m.SaveChanges();

            //return RedirectToAction("Index", "CV");

            List<aspnet_Users> user = m.aspnet_Users.ToList();
            string name = User.Identity.Name;
            aspnet_Users kullan = user.Find(x => x.UserName.Equals(name));
            c.UserId = kullan.UserId;
            m.CV.Add(c);
            m.SaveChanges();
            return RedirectToAction("Index", "CV");
        }
    }
}