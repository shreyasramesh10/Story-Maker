using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPFinalPrj.Controllers
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
            ViewBag.Message = "You can reach us at:";

            return View();
        }
        public ActionResult Instructions()
        {
            return View();
        }
        public ActionResult SiteMap()
        {
            return View();
        }
    }
}