using SupperSlonicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace SupperSlonicWebSite
{
    public static class HtmlHelperExtension
    {
        public static IEnumerable<MvcHtmlString> GetTabWidgets(this HtmlHelper<IList<TabWidgetModel>> htmlHelper, int topShift)
        {
            int top = topShift;

            foreach (TabWidgetModel tabWidget in htmlHelper.ViewData.Model)
            {
                tabWidget.Top = String.Format("{0}px", top);
                yield return htmlHelper.DisplayFor(m => tabWidget, "TabWidget");
                top += 101;
            }
        }
    }
}