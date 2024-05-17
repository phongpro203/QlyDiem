using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlyDiem
{
    internal class Connection
    {
        private static string sqlcoconnectstring = "server=(local);database=Qlydiem;integrated security=true";
        public static SqlConnection getSqlConnection()
        {
            return new SqlConnection(sqlcoconnectstring);
        }
    }
}
