using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineIs.Models;

namespace OnlineIs.Controllers
{
    
    public class AdminController : Controller
    {
        Model1 m = new Model1();
        // GET: Admin
       [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View();
        }
      
  
    }
}