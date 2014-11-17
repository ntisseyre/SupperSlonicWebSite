using SupperSlonicWebSite.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SupperSlonicWebSite.DomainLogic.DAL
{
    public interface ISourceCodeDownloadsDAL
    {
        IList<DownloadInfoModel> GetDownloadsInfo(SqlTransaction transaction);        

        void CreateDownload(SqlTransaction transaction, string codeName);
    }
}
