using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperSlonicWebSite.Controllers
{
    public class SocialNetworksController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OwinAuthentication()
        {
            return View();
        }
    }
}
