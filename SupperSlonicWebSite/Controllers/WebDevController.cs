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
            List<TabWidgetModel> model = new List<TabWidgetModel>();
            model.Add(new TabWidgetModel("description", Alignment.Right, "100px", Url.Action("VerticalTabs", "WebDev")));
            model.Add(new TabWidgetModel("howToUse", Alignment.Right, "201px", Url.Action("ScheduleTable", "WebDev")));
            return View(model);
        }
    }
}
