using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compraventa_EL_Comodo
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {

        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public DbConnection GetDbConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("NorthwindConnectionString"));
        }
    }
}
