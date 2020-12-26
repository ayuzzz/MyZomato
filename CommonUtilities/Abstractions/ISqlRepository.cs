using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace CommonUtilities.Abstractions
{
    public interface ISqlRepository
    {
        DbConnection GetDbConnection();
        Task<IEnumerable<T>> ExecuteAsync<T>(string query = null, DynamicParameters parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60);
        Task<IEnumerable<T>> QueryAsync<T>(string query = null, DynamicParameters parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60);
    }
}
