using SupperSlonicDomain.Models.SourceCodeDownload;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SupperSlonicDomain.DAL
{
    public interface ISourceCodeDownloadsDAL
    {
        IList<DownloadInfo> GetDownloadsInfo(SqlTransaction transaction);        

        void CreateDownload(SqlTransaction transaction, string codeName);
    }
}
