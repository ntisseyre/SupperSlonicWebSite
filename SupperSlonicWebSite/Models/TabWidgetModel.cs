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
            this.Id = id;
            this.Alignment = alignment;
            this.Top = top;
        }

        public String Id { get; set; }

        public Alignment Alignment { get; set; }

        public String Top { get; set; }

        public String TabImage
        {
            get { return "~/Content/img/" + this.Id + ".png"; }
        }

        public String Href 
        {
            get { return "#" + this.Id + "Anchor"; }
        }
    }
}