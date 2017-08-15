using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SqlHelper
    {
        // dataSource  (nokta olan yeri sqldeki pc adını yaz baglantı kurulsun )
        private const string ConnectionString = "Data Source=.; Initial Catalog =BusManagementDb; Integrated Security = true;";

        public static SqlCommand createSqlCommand()
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = ConnectionString;

            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConn;

            return sqlComm;
        }
    }
}
