using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SupperSlonicWebSite
{
    public static class RazorLayouts
    {
        public static void InitTemplates()
        {
            var config = new TemplateServiceConfiguration()
            {
                BaseTemplateType = typeof(RazorTemplateBase<>)
            };

            Razor.SetTemplateService(new TemplateService(config));

            AddTemplate("HelpSpotWidget", "~/Views/Shared/HelpSpotWidget.cshtml");
        }

        public static void AddWebApiLayout()
        {
            AddTemplate("_WebApiLayout.cshtml", "~/Views/WebApi/_WebApiLayout.cshtml");
        }

        private static void AddTemplate(string layoutName, string templatePath)
        {
            string templateContent = File.ReadAllText(HttpContext.Current.Server.MapPath(templatePath));
            Razor.Compile(templateContent, layoutName);
        }
    }

    public class RazorTemplateBase<T> : TemplateBase<T>
    {
        private RazorUrlHelper urlHelper = new RazorUrlHelper();

        private RazorHtmlHelper htmlHelper = new RazorHtmlHelper();

        public RazorUrlHelper Url
        {
            get { return this.urlHelper; }
        }

        public RazorHtmlHelper Html
        {
            get { return this.htmlHelper; }
        }
    }

    public class RazorHtmlHelper
    {
        public IEncodedString Partial(string viewName)
        {
            ITemplate template = Razor.Resolve(viewName);

            ExecuteContext ec = new ExecuteContext();

            RawString result = new RawString(template.Run(ec));

            return result;
        }
    }

    public class RazorUrlHelper
    {
        public string Content(string virtualPath)
        {
            return virtualPath.Substring(1, virtualPath.Length - 1);
        }

        public string Encode(string url)
        {
            return Uri.EscapeUriString(url);
        }
    }
}