using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SupperSlonicWebSite.DomainLogic.DAL
{
    class BaseDAL : IBaseDAL
    {
        public void Execute(IsolationLevel isolationLevel, Action<SqlTransaction> action)
        {
            using (var connection = CreateSqlConnection())
            {
                connection.Open();

                using (SqlTransaction tran = connection.BeginTransaction(isolationLevel))
                {
                    action(tran);
                    tran.Commit();
                }
            }
        }

        public TResult Execute<TResult>(IsolationLevel isolationLevel, Func<SqlTransaction, TResult> function)
        {
            using (var connection = CreateSqlConnection())
            {
                connection.Open();

                using (SqlTransaction tran = connection.BeginTransaction(isolationLevel))
                {
                    var result = function(tran);
                    tran.Commit();

                    return result;
                }
            }
        }

        internal static object ToSqlNullable<T>(T value)
        {
            if (value == null)
                return DBNull.Value;
            else
                return value;
        }

        internal static T GetObjectOrNull<T>(object value) where T : class
        {
            return (value is DBNull) ? (T)null : (T)value;
        }

        internal static Nullable<T> GetValueOrNull<T>(object value) where T : struct
        {
            return (value is DBNull) ? (Nullable<T>)null : (T)value;
        }

        private static SqlConnection CreateSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MidgaardDB"].ConnectionString);
        }
    }
}