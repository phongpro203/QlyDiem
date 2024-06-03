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
        private static string sqlcoconnectstring = "Data Source=(local);Initial Catalog=QlyDiem;Integrated Security=True";
        public static SqlConnection getSqlConnection()
        {
            return new SqlConnection(sqlcoconnectstring);
        }
    }
}
