using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
                connection.Close();
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
                connection.Close();
            }
        }
    }
}