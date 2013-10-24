using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupperSlonicWebSite.Models;
using System.Net.Mail;
using System.Net;
using System.Web.Helpers;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using SupperSlonicWebSite.DomainLogic.DAL;

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
            List<TabWidgetModel> model = new List<TabWidgetModel>();
            model.Add(new TabWidgetModel("description", Alignment.Right, "100px"));
            model.Add(new TabWidgetModel("howToUse", Alignment.Right, "201px"));
            model.Add(new TabWidgetModel("placeHoldersInTemplate", Alignment.Right, "302px"));
            model.Add(new TabWidgetModel("templateStructure", Alignment.Right, "403px"));
            return View(model);
        }

        public ActionResult DynamoDB()
        {
            List<TabWidgetModel> model = new List<TabWidgetModel>();
            model.Add(new TabWidgetModel("description", Alignment.Right, "100px"));
            model.Add(new TabWidgetModel("versioning", Alignment.Right, "201px"));
            model.Add(new TabWidgetModel("deployment", Alignment.Right, "302px"));
            model.Add(new TabWidgetModel("locking", Alignment.Right, "403px"));
            return View(model);
        }

        public FileResult DownloadExample(String id)
        {            
            String downloadLink = ConfigurationManager.AppSettings[String.Format("{0}ExampleUrl", id)];
            if (downloadLink == null)
                return null;

            SourceCodeDownloadsDAL dal = new SourceCodeDownloadsDAL();
            dal.InsertDownload(id);

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
            String from = "info@supperslonic.com";
            String displayNameFrom = "SupperSlonic Web site";
            String to = "natalia.a.zelenskaya@gmail.com";

            using (SmtpClient client = new SmtpClient("relay-hosting.secureserver.net"))
            {
                //client.Credentials = new NetworkCredential(from, "bebebe");
                //client.Port = 3535;

                //client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Port = 25;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(from, displayNameFrom);
                mailMessage.ReplyToList.Add(from);
                mailMessage.To.Add(to);

                mailMessage.Subject = "Help me!";
                mailMessage.Body = String.Format("From:{0}<br/>{1}", email, message);
                mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);
            }

            return Json("Success");
        }
    }
}
