using OnlineIs.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineIs.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Kullanici k, string Hatirla)
        {

            bool sonuc = Membership.ValidateUser(k.KullaniciAdi, k.Parola);

            if (sonuc)
            {
                if (Hatirla == "on")
                {
                    FormsAuthentication.RedirectFromLoginPage(k.KullaniciAdi, true);
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(k.KullaniciAdi, false);
                }
                return RedirectToAction("Index", "Anasayfa");

            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı adı veya parola hatalı.";
                return View();
            }
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap");
        }

        public ActionResult ParolamiUnuttum()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ParolamiUnuttum(Kullanici k)
        {
            MembershipUser mu = Membership.GetUser(k.KullaniciAdi);
            if (mu.PasswordQuestion == k.GizliSoru)
            {
                string pwd = mu.ResetPassword(k.GizliCevap);
                mu.ChangePassword(pwd, k.Parola);
                return RedirectToAction("GirisYap");


            }
            else
            {
                ViewBag.Mesaj = "Girilen bilgiler yanlıştır.";
                return View();
            }
        }
    }
}