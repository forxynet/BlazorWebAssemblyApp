using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary {
    public class SqlDataAccess : ISqlDataAccess {
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = "Default";
        public SqlDataAccess(IConfiguration config) {
            _config = config;
        }
        public string GetConnectionString() {
            return _config.GetConnectionString(ConnectionStringName);
        }
        public async Task<List<T>> LoadData<T, P>(string sql, P paramater) {
            using (IDbConnection con = new SqlConnection(GetConnectionString())) {
                var data = await con.QueryAsync<T>(sql, paramater);
                return data.ToList();
            }
        }
        public async Task SaveData<T>(string sql, T paramater) {        
            using (IDbConnection connection = new SqlConnection(GetConnectionString())) {
                await connection.ExecuteAsync(sql, paramater);
            }
        }

        public async Task UpdateData<T>(string sql, T paramater) {           
            using (IDbConnection con = new SqlConnection(GetConnectionString())) {
                await con.ExecuteAsync(sql,paramater);
            }
        }

        public async Task DeletePerson<T>(string sql, T paramater) {
            using (IDbConnection con = new SqlConnection(GetConnectionString())) {
                await con.ExecuteAsync(sql, paramater);
            }
        }
    }
}
