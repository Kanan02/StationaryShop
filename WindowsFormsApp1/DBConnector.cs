using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class DBConnector
    {
        public string ConnectionString { get; set; }
        public DBConnector(string connstr)
        {
            ConnectionString = connstr;
        }
        public SqlConnection Connect()
        {
            return new SqlConnection(ConnectionString);
        }

        public void Disconnect(SqlConnection connection)
        {
            connection.Close();
        }
    }
}
