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
            model.Add(new TabWidgetModel("model"));
            model.Add(new TabWidgetModel("view"));
            model.Add(new TabWidgetModel("controller"));
            model.Add(new TabWidgetModel("howToUse"));
            return View(model);
        }

        public ActionResult WeeklySchedule()
        {
            List<TabWidgetModel> model = new List<TabWidgetModel>(5);
            model.Add(new TabWidgetModel("description"));
            model.Add(new TabWidgetModel("model"));
            model.Add(new TabWidgetModel("view"));
            model.Add(new TabWidgetModel("controller"));
            model.Add(new TabWidgetModel("howToUse"));
            return View(model);
        }

        public ActionResult AgileReleaseCycleCalendar()
        {
            List<TabWidgetModel> model = new List<TabWidgetModel>(5);
            model.Add(new TabWidgetModel("description"));
            model.Add(new TabWidgetModel("model"));
            model.Add(new TabWidgetModel("view"));
            model.Add(new TabWidgetModel("controller"));
            model.Add(new TabWidgetModel("howToUse"));
            return View(model);
        }

        public ActionResult ColorPicker()
        {
            return View();
        }
    }
}
