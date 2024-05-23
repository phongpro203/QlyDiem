using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyDiem
{
    internal class MHModify
    {
        SqlCommand sqlCommand = null;
        SqlConnection connection = null;
        SqlDataAdapter da = null;
        public DataTable getAllMonHoc()
        {
            DataTable dt = new DataTable();
            connection = Connection.getSqlConnection();
            connection.Open();
            string sql = "select * from MonHoc";
            da = new SqlDataAdapter(sql, connection);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        public bool insert(MonHoc mh)
        {
            connection = Connection.getSqlConnection();
            string sql = "insert into MonHoc values (@MaMon,@TenMon,@SoTinChi)";
            try
            {
                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@MaMon", SqlDbType.NVarChar).Value = mh.MaMon;
                sqlCommand.Parameters.Add("@TenMon", SqlDbType.NVarChar).Value= mh.TenMon;
                sqlCommand.Parameters.Add("@SoTinChi", SqlDbType.Int).Value = mh.SoTinChi;
                sqlCommand.ExecuteNonQuery();//thuc thi lenh truy van
                    
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627) // Mã lỗi cho "Nhập trùng khóa"
                {
                    MessageBox.Show("Mã môn đã tồn tại trong cơ sở dữ liệu.");
                    return false;
                }
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
        public bool update(MonHoc mh)
        {
            connection = Connection.getSqlConnection();
            string sql = "update MonHoc set TenMon = @TenMon, SoTinChi = @SoTinChi where MaMon = @MaMon";
            try
            {
                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@MaMon", SqlDbType.NVarChar).Value = mh.MaMon;
                sqlCommand.Parameters.Add("@TenMon", SqlDbType.NVarChar).Value = mh.TenMon;
                sqlCommand.Parameters.Add("@SoTinChi", SqlDbType.Int).Value = mh.SoTinChi;
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
        public bool delete(string MaMon)
        {
            connection = Connection.getSqlConnection();
            string sql = "delete MonHoc where MaMon = @MaMon";
            try
            {
                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@MaMon", SqlDbType.NVarChar).Value = MaMon;
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
        public DataTable search(string MaMon)
        {
            DataTable dt = new DataTable();
            connection = Connection.getSqlConnection();
            connection.Open();
            string sql = "select * from MonHoc where MaMon = '"+MaMon+"'";
            da = new SqlDataAdapter(sql, connection);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
    }
}
