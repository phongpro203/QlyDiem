using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyDiem
{
    internal class Connection
    {
        private static string sqlcoconnectstring = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\QlyDiem.mdf;Integrated Security=True;Connect Timeout=30";
        public static SqlConnection getSqlConnection()
        {
            return new SqlConnection(sqlcoconnectstring);
        }
    }
}
