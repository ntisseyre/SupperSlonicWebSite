using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperSlonicWebSite.Models
{
    public class TabWidgetModel
    {
        public TabWidgetModel(String id, Alignment alignment, String top)
        {
            this.Id = "tab" + id;
            this.Alignment = alignment;
            this.Top = top;
            this.TabImage = "~/Content/img/" + id + ".png";
            this.Href = "#" + id;
        }

        public String Id { get; private set; }

        public Alignment Alignment { get; private set; }

        public String Top { get; private set; }

        public String TabImage { get; private set; }

        public String Href { get; private set; }
    }
}