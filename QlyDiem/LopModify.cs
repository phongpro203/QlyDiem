using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlyDiem
{
    internal class LopModify
    {
        SqlCommand sqlCommand = null;
        SqlConnection connection = null;
        SqlDataAdapter da = null;
        public DataTable getAllopHoc()
        {
            DataTable dt = new DataTable();

            connection = Connection.getSqlConnection();
            connection.Open();
            string sql = "Select Lop.MaLop, Lop.TenLop, Khoa.TenKhoa from Lop, Khoa where Lop.MaKhoa = Khoa.MaKhoa";
            da = new SqlDataAdapter(sql, connection);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        public bool insertlop(Lop lop)
        {
            connection = Connection.getSqlConnection();
            string sql = "insert into Lop (Malop, Tenlop, MaKhoa) values (@Malop, @Tenlop, @MaKhoa)";
            try
            {

                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@Malop", SqlDbType.NVarChar).Value = lop.MaLop;
                sqlCommand.Parameters.Add("@Tenlop", SqlDbType.NVarChar).Value = lop.TenLop;
                sqlCommand.Parameters.Add("@MaKhoa", SqlDbType.NVarChar).Value = lop.Khoa;
                sqlCommand.ExecuteNonQuery();//thuc thi lenh truy van

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public bool update(Lop lop)
        {
            connection = Connection.getSqlConnection();
            string sql = "update Lop set Tenlop = @Tenlop, MaKhoa = @MaKhoa where Malop = @Malop";
            try
            {
                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@Malop", SqlDbType.NVarChar).Value = lop.MaLop;
                sqlCommand.Parameters.Add("@Tenlop", SqlDbType.NVarChar).Value = lop.TenLop;
                sqlCommand.Parameters.Add("@MaKhoa", SqlDbType.NVarChar).Value = lop.Khoa;
                sqlCommand.ExecuteNonQuery();//thuc thi lenh truy van

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public DataTable search(string Malop)
        {
            DataTable dt = new DataTable();
            connection = Connection.getSqlConnection();
            connection.Open();
            string sql = "select * from Lop where Malop = '" + Malop + "'";
            da = new SqlDataAdapter(sql, connection);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        public bool delete(string Lop)
        {
            connection = Connection.getSqlConnection();
            string sql = "delete Lop where Malop = @Malop";
            try
            {
                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@Malop", SqlDbType.NVarChar).Value = Lop;
                sqlCommand.ExecuteNonQuery();//thuc thi lenh truy van

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

    }
}

