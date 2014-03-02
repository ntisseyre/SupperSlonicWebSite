using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperSlonicWebSite.Models
{
    public class TabWidgetModel
    {
        public TabWidgetModel(String id) :
            this(id, Alignment.Right, "#" + id)
        {
        }

        public TabWidgetModel(String id, Alignment alignment, String href)
        {
            this.Id = "tab" + id;
            this.Alignment = alignment;
            this.TabImage = "~/Content/img/tabs/" + id + ".png";
            this.Href = href;
        }

        public String Id { get; private set; }

        public Alignment Alignment { get; private set; }

        public String Top { get; set; }

        public String TabImage { get; private set; }

        public String Href { get; private set; }
    }
}