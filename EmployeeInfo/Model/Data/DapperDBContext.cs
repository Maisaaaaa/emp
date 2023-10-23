using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeInfo.Model.Data
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;
        public DapperDBContext(IConfiguration configuration) {
            this._configuration = configuration;
            this.connectionstring = this._configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection()=>new SqlConnection(connectionstring);

    }
}
