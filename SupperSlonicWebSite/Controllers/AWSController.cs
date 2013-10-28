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
 
        public ActionResult AmazonContext()
        {
            return View();
        }

        public ActionResult ElasticMapReduce()
        {
            List<TabWidgetModel> model = new List<TabWidgetModel>(4);
            model.Add(new TabWidgetModel("description", Alignment.Right, "100px"));
            model.Add(new TabWidgetModel("howToUse", Alignment.Right, "201px"));
            model.Add(new TabWidgetModel("placeHoldersInTemplate", Alignment.Right, "302px"));
            model.Add(new TabWidgetModel("templateStructure", Alignment.Right, "403px"));
            return View(model);
        }

        public ActionResult DynamoDB()
        {
            List<TabWidgetModel> model = new List<TabWidgetModel>(4);
            model.Add(new TabWidgetModel("description", Alignment.Right, "100px"));
            model.Add(new TabWidgetModel("versioning", Alignment.Right, "201px"));
            model.Add(new TabWidgetModel("deployment", Alignment.Right, "302px"));
            model.Add(new TabWidgetModel("locking", Alignment.Right, "403px"));
            return View(model);
        }
    }
}
