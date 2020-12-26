using CommonUtilities.Abstractions;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities
{
    public class SqlRepository : ISqlRepository
    {
        private readonly IConfiguration _configuration;
        private string _connectionstring = "";
        private readonly string _server = @"LAPTOP-HL47RBNK\AYUZZZSQLSERVER";
        private readonly string _database = @"myzomato-dev-01";
        private readonly string _username = @"admin";
        private readonly string _password = @"root@123";

        public SqlRepository(IConfiguration config)
        {
            _configuration = config;
            _connectionstring += $"Data Source={_server};Initial Catalog={_database};User ID={_username};Password={_password}";
        }

        public DbConnection GetDbConnection()
        {
            //return new SqlConnection(_configuration.GetConnectionString(_connectionstring));
            return new SqlConnection(_connectionstring);
        }

        public Task<IEnumerable<T>> ExecuteAsync<T>(string query = null, DynamicParameters parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query = null, DynamicParameters parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60)
        {
            using (IDbConnection db = GetDbConnection())
            {
                return await db.QueryAsync<T>(sql : query, param: parameters, commandType : commandType, commandTimeout : commandTimeOut);
            }
        }
    }
}
