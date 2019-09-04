using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;
namespace OnlineIs.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}