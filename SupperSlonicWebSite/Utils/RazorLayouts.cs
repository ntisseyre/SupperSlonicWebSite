using RazorEngine;
using System.IO;
using System.Web;

namespace SupperSlonicWebSite
{
    public static class RazorLayouts
    {
        public static void AddNotificationLayout()
        {
            AddLayout("_Layout.cshtml", "~/Views/Shared/_NotificationLayout.cshtml");
        }

        private static void AddLayout(string layoutName, string layoutPath)
        {
            string layoutContent = File.ReadAllText(HttpContext.Current.Server.MapPath(layoutPath));
            Razor.Compile(layoutContent, layoutName);
        }
    }
}