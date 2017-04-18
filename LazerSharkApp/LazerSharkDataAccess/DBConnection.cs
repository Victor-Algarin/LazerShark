using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkDataAccess
{
    static class DBConnection
    {
        internal static SqlConnection GetConnection()
        {
            var connString = @"Data Source=localhost;Initial Catalog=LazerSharkDB;Integrated Security=True";
            var conn = new SqlConnection(connString);
            return conn;
        }
    }
}
