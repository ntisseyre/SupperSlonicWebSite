using SupperSlonicWebSite.DomainLogic.Logic;
using SupperSlonicWebSite.Models;
using SupperSlonicWebSite.Models.Email;
using SupperSlonicWebSite.Providers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SupperSlonicWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public FileResult DownloadExample(String id)
        {
            String downloadLink = ConfigurationManager.AppSettings[String.Format("{0}ExampleUrl", id)];
            if (downloadLink == null)
                return null;

            SourceCodeDownloadsManager manager = new SourceCodeDownloadsManager();
            manager.CreateDownloadAsync(id);

            byte[] data;
            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("Accept", "application/zip");
                webClient.Headers.Add("user-agent", ConfigurationManager.AppSettings["UserAgent"]);
                data = webClient.DownloadData(downloadLink);
            }

            return File(data, "application/zip", String.Format("{0}Example.zip", id));
        }

        [HttpPost]
        public JsonResult SendEmail(String email, String message)
        {
            var model = new HelpMe()
            {
                From = email,
                Message = message
            };

            new EmailProvider().SendHelpMeAsync(model);

            return Json("Success");
        }

        public async Task<ActionResult> DownloadsInfo()
        {
            SourceCodeDownloadsManager manager = new SourceCodeDownloadsManager();
            IList<DownloadInfoModel> model = await manager.GetDownloadsInfoAsync();

            return View(model);
        }
    }
}
