using SupperSlonicWebSite.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SupperSlonicWebSite.Controllers
{
    public class WebControlsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerticalTabs()
        {
            List<TabWidgetModel> model = new List<TabWidgetModel>(4);
            model.Add(new TabWidgetModel("model", Alignment.Right, "100px"));
            model.Add(new TabWidgetModel("view", Alignment.Right, "201px"));
            model.Add(new TabWidgetModel("controller", Alignment.Right, "302px"));
            model.Add(new TabWidgetModel("howToUse", Alignment.Right, "403px"));
            return View(model);
        }

        public ActionResult WeeklySchedule()
        {
            List<TabWidgetModel> model = new List<TabWidgetModel>(5);
            model.Add(new TabWidgetModel("description", Alignment.Right, "100px"));
            model.Add(new TabWidgetModel("model", Alignment.Right, "201px"));
            model.Add(new TabWidgetModel("view", Alignment.Right, "302px"));
            model.Add(new TabWidgetModel("controller", Alignment.Right, "403px"));
            model.Add(new TabWidgetModel("howToUse", Alignment.Right, "504px"));
            return View(model);
        }

        public ActionResult AgileReleaseCycleCalendar()
        {
            List<TabWidgetModel> model = new List<TabWidgetModel>(5);
            model.Add(new TabWidgetModel("description", Alignment.Right, "100px"));
            model.Add(new TabWidgetModel("model", Alignment.Right, "201px"));
            model.Add(new TabWidgetModel("view", Alignment.Right, "302px"));
            model.Add(new TabWidgetModel("controller", Alignment.Right, "403px"));
            model.Add(new TabWidgetModel("howToUse", Alignment.Right, "504px"));
            return View(model);
        }

        public ActionResult ColorPicker()
        {
            return View();
        }
    }
}
