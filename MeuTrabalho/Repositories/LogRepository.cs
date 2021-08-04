using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MeuTrabalho.Repositories
{
    public class LogRepository : ILogRepository
    {
        string _connectionString;

        public LogRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int TotalRegistros()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                int total = connection.Query("SELECT count = COUNT(*) FROM tbLog").First().count;

                return total;
            }
        }
        public void InserirLog(string campo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute("INSERT tbLog VALUES (@p1)", new { p1 = campo });                
            }
        }
    }
}
