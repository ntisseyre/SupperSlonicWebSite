using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupperSlonicWebSite.Models;
using System.Web.Helpers;
using System.IO;
using System.IO.Compression;

namespace SupperSlonicWebSite.Controllers
{
    public class AWSController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmrWorkflow()
        {
            List<TabWidgetModel> model = new List<TabWidgetModel>(4);
            model.Add(new TabWidgetModel("description"));
            model.Add(new TabWidgetModel("model"));
            model.Add(new TabWidgetModel("api"));
            return View(model);
        }

        public ActionResult DynamoDB()
        {
            List<TabWidgetModel> model = new List<TabWidgetModel>(4);
            model.Add(new TabWidgetModel("description"));
            model.Add(new TabWidgetModel("versioning"));
            model.Add(new TabWidgetModel("deployment"));
            model.Add(new TabWidgetModel("locking"));
            return View(model);
        }
    }
}
