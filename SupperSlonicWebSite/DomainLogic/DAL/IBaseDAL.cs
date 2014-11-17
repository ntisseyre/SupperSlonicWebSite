using System;
using System.Data;
using System.Data.SqlClient;

namespace SupperSlonicWebSite.DomainLogic.DAL
{
    public interface IBaseDAL
    {
        void Execute(IsolationLevel isolationLevel, Action<SqlTransaction> action);

        TResult Execute<TResult>(IsolationLevel isolationLevel, Func<SqlTransaction, TResult> function);
    }
}
