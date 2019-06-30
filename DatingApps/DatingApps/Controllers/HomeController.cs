using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatingApps.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "登録をしてください。";

            return View();
        }

        [HttpPost]
        public ActionResult UserPage(string id, string password)
        {
            ViewData["id"] = id + "を受け取った";
            return View();
        }
    }
}