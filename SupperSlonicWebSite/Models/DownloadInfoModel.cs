using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupperSlonicWebSite.Models
{
    public class DownloadInfoModel
    {
        public String Name { get; set; }

        public int TotalDownloads { get; set; }

        public DateTime LatestDownload { get; set; }
    }
}