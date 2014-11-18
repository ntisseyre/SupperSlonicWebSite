using SupperSlonicDomain.Models.SourceCodeDownload;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SupperSlonicDomain.DAL
{
    class SourceCodeDownloadsDAL : ISourceCodeDownloadsDAL
    {
        public IList<DownloadInfo> GetDownloadsInfo(SqlTransaction transaction)
        {
            var result = new List<DownloadInfo>();

            using (SqlCommand cmd = new SqlCommand("[dbo].[spGetDownloadsInfo]", transaction.Connection, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        var info = new DownloadInfo();
                        info.Name = (string)sqlDataReader["Name"];
                        info.TotalDownloads = (int)sqlDataReader["TotalDownloads"];
                        info.LatestDownload = sqlDataReader.GetValueOrNull<DateTime>("LatestDownload");
                        
                        result.Add(info);
                    }
                }
            }

            return result;
        }

        public void CreateDownload(SqlTransaction transaction, string codeName)
        {
            using (SqlCommand cmd = new SqlCommand("[dbo].[spCreateSourceCodeDownload]", transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("codeName", codeName);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
        }
    }
}