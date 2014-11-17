using SupperSlonicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SupperSlonicWebSite.DomainLogic.DAL
{
    class SourceCodeDownloadsDAL : ISourceCodeDownloadsDAL
    {
        public IList<DownloadInfoModel> GetDownloadsInfo(SqlTransaction transaction)
        {
            IList<DownloadInfoModel> result = new List<DownloadInfoModel>();

            using (SqlCommand cmd = new SqlCommand("[dbo].[spGetDownloadsInfo]", transaction.Connection, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        DownloadInfoModel info = new DownloadInfoModel();
                        info.Name = (string)sqlDataReader["Name"];
                        info.TotalDownloads = (int)sqlDataReader["TotalDownloads"];
                        info.LatestDownload = (DateTime)sqlDataReader["LatestDownload"];

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