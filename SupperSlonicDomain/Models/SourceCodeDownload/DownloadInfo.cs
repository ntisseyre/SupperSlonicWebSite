using System;

namespace SupperSlonicDomain.Models.SourceCodeDownload
{
    public class DownloadInfo
    {
        public String Name { get; set; }

        public int TotalDownloads { get; set; }

        public DateTime? LatestDownload { get; set; }
    }
}
