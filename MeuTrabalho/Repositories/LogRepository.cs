using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Repositories
{
    public class LogRepository
    {
        string _connectionString;

        public LogRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int TotalRegistros()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM tbLog", _connection);

                var reader = command.ExecuteReader();
                int total = 0;
                while (reader.Read())
                {
                    total = total + 1;
                }

                return total;
            }
        }
    }
}
