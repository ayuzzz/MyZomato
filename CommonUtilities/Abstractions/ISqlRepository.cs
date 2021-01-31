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
        Task<int> ExecuteAsync(string query = null, dynamic parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60);
        Task<IEnumerable<T>> QueryAsync<T>(string query = null, dynamic parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60);
        Task<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>> QueryMultipleAsync<TFirst, TSecond>
            (string query = null, dynamic parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60);
        Task<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>, IEnumerable<TThird>>> QueryMultipleAsync<TFirst, TSecond, TThird>
            (string query = null, dynamic parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60);
        
    }
}
