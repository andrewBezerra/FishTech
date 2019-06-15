using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager._infra
{
    public class MSSQL : IDB
    {
        private SqlConnection _connection;
        private IConfiguration _configuration;

        public MSSQL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }

        public DbConnection GetConnection()
        {
            return _connection = new SqlConnection(_configuration.GetConnectionString("SQLDB"));
        }
    }
}
