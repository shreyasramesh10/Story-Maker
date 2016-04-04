using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPFinalPrj.Controllers
{
    public class AllRolesController : Controller
    {
        // GET: AllRoles

        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "user")]
        public ActionResult Foo()
        {
            return View();
        }
    }
}