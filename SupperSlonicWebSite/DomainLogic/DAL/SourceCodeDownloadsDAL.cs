using SupperSlonicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SupperSlonicWebSite.DomainLogic.DAL
{
    public class SourceCodeDownloadsDAL
    {
        public void InsertSourceCodeExample(String name)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MidgaardDB"].ConnectionString))
            using(SqlCommand cmd = new SqlCommand("insert into dbo.clSourceCodeExample (Name) values (@name)", connection))
            {
                cmd.Parameters.Add("name", SqlDbType.VarChar, 255).Value = name;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertDownload(String codeName)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MidgaardDB"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.InsertDownloadRecord", connection))
            {
                cmd.Parameters.Add("codeName", SqlDbType.VarChar, 255).Value = codeName;
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IList<DownloadInfoModel> GetDownloadsInfo()
        {
            IList<DownloadInfoModel> result = new List<DownloadInfoModel>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MidgaardDB"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("select * from dbo.HowManyDownloads order by Name", connection))
            {
                connection.Open();
                using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        DownloadInfoModel info = new DownloadInfoModel();
                        info.Name = sqlDataReader.GetString(0);
                        info.TotalDownloads = sqlDataReader.GetInt32(1);
                        info.LatestDownload = sqlDataReader.GetDateTime(2);

                        result.Add(info);
                    }
                }
            }

            return result;
        }
    }
}