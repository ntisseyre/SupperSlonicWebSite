using System;
using System.Data.SqlClient;

namespace SupperSlonicWebSite.DomainLogic.DAL
{
    public static class Helper
    {
        public static object ToSqlNullable<T>(T value)
        {
            if (value == null)
                return DBNull.Value;
            else
                return value;
        }

        public static T GetObjectOrNull<T>(this SqlDataReader sqlDataReader, string columnName) where T : class
        {
            var columnValue = sqlDataReader[columnName];
            return (columnValue is DBNull) ? (T)null : (T)columnValue;
        }

        public static Nullable<T> GetValueOrNull<T>(this SqlDataReader sqlDataReader, string columnName) where T : struct
        {
            var columnValue = sqlDataReader[columnName];
            return (columnValue is DBNull) ? (Nullable<T>)null : (T)columnValue;
        }
    }
}