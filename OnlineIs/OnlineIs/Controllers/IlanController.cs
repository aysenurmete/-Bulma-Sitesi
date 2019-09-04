using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;

namespace OnlineIs.Controllers
{
    public class IlanController : Controller
    {
        Model1 m = new Model1();
        // GET: Ilan
        public ActionResult Index()
        {
            List<ILAN> i = m.ILAN.ToList();
            return View(i);
        }
        [Authorize(Roles = "Şirket")]
        public ActionResult IlanEkle()
        {
            List<DEPARTMAN> dprtmn = m.DEPARTMAN.ToList();
            List<POZISYON> pzsyn = m.POZISYON.ToList();
            List<CALISMASEKLI> clsm = m.CALISMASEKLI.ToList();
            List<EGITIMSEVIYESI> egtm = m.EGITIMSEVIYESI.ToList();
            List<YABANCIDIL> ydil = m.YABANCIDIL.ToList();
            //List<aspnet_Users> user = m.aspnet_Users.ToList();
            //List<ISVEREN> isveren = m.ISVEREN.ToList();



            //ILAN i = new ILAN();
            //string name=User.Identity.Name;

            //ISVEREN kullanici=  isveren.Find(item => item.isverenADI.Equals(name));
            //i.isverenID = kullanici.isverenID;
            



            ViewBag.Departman = dprtmn;
            ViewBag.Pozisyon = pzsyn;
            ViewBag.CalismaSekli = clsm;
            ViewBag.EgitimSeviyesi = egtm;
            ViewBag.Ydil = ydil;
            return View();
        }
        [HttpPost]
        public ActionResult IlanEkle(ILAN i)
        {
            List<aspnet_Users> user = m.aspnet_Users.ToList();
            string name = User.Identity.Name;

            aspnet_Users kullan = user.Find(item => item.UserName.Equals(name));
            i.UserId = kullan.UserId;


            m.ILAN.Add(i);
            m.SaveChanges();
            return RedirectToAction("Index", "Ilan");
            
        }
    
    }
}