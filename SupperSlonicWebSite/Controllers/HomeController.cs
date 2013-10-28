using SupperSlonicWebSite.DomainLogic.DAL;
using SupperSlonicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
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

        public ActionResult DownloadsInfo()
        {
            SourceCodeDownloadsDAL dal = new SourceCodeDownloadsDAL();
            IList<DownloadInfoModel> model = dal.GetDownloadsInfo();

            return View(model);
        }
    }
}
