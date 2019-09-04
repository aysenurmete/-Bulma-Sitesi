using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineIs.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<string> roller = Roles.GetAllRoles().ToList();

            return View(roller);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(string RolAdi)
        {
            Roles.CreateRole(RolAdi);
            return RedirectToAction("Index");
        }
    
    }
}