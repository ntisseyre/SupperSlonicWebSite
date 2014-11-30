using SupperSlonicWebSite.Models;
using System.Collections.Generic;
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
            List<TabWidgetModel> model = new List<TabWidgetModel>(4);
            model.Add(new TabWidgetModel("description"));
            model.Add(new TabWidgetModel("owin"));
            model.Add(new TabWidgetModel("demo"));
            return View(model);
        }
    }
}
