using SupperSlonicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperSlonicWebSite.Controllers
{
    public class WebDevController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerticalTabs()
        {
            return View();
        }

        public ActionResult WeeklySchedule()
        {
            return View();
        }
    }
}
