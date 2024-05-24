using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyDiem
{
    internal class GVModify
    {
        SqlCommand sqlCommand = null;
        SqlConnection connection = null;
        SqlDataAdapter da = null;
        public DataTable getAllGiangVien()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT GiangVien.MaGV, GiangVien.TenGV, Khoa.TenKhoa, GiangVien.NgaySinh, GiangVien.QueQuan, GiangVien.GioiTinh, GiangVien.TrinhDo FROM GiangVien " +
                "INNER JOIN Khoa ON GiangVien.MaKhoa = Khoa.MaKhoa;";
            connection = Connection.getSqlConnection();
            connection.Open();
            da = new SqlDataAdapter(sql, connection);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        public bool insertGV(GiangVien gv)
        {
            connection = Connection.getSqlConnection();
            string sql = "insert into GiangVien (MaGV, TenGV, MaKhoa, NgaySinh,QueQuan, GioiTinh, TrinhDo) values (@MaGV, @TenGV, @MaKhoa, @NgaySinh, @QueQuan, @GioiTinh, @TrinhDo)";
            try
            {

                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@MaGV", SqlDbType.NVarChar).Value = gv.MaGV;
                sqlCommand.Parameters.Add("@TenGV", SqlDbType.NVarChar).Value = gv.TenGV;
                sqlCommand.Parameters.Add("@MaKhoa", SqlDbType.NVarChar).Value = gv.MaKhoa;
                sqlCommand.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = gv.NgaySinh;
                sqlCommand.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = gv.QueQuan;
                sqlCommand.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = gv.GioiTinh;
                sqlCommand.Parameters.Add("@TrinhDo", SqlDbType.NVarChar).Value = gv.TrinhDo;
                sqlCommand.ExecuteNonQuery();//thuc thi lenh truy van

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627) // Mã lỗi cho "Nhập trùng khóa"
                {
                    MessageBox.Show("Mã giảng viên đã tồn tại trong cơ sở dữ liệu.");
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
        public bool updateGV(GiangVien gv)
        {
            using (connection = Connection.getSqlConnection())
            {
                string sql = "update GiangVien set TenGV = @TenGV, MaKhoa = @MaKhoa, NgaySinh = @NgaySinh, QueQuan = @QueQuan, GioiTinh = @GioiTinh, TrinhDo = @TrinhDo where MaGV = @MaGV";

                try
                {
                    connection.Open();
                    using (sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.Parameters.Add("@MaGV", SqlDbType.NVarChar).Value = gv.MaGV;
                        sqlCommand.Parameters.Add("@TenGV", SqlDbType.NVarChar).Value = gv.TenGV;
                        sqlCommand.Parameters.Add("@MaKhoa", SqlDbType.NVarChar).Value = gv.MaKhoa;
                        sqlCommand.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = gv.NgaySinh;
                        sqlCommand.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = gv.QueQuan;
                        sqlCommand.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = gv.GioiTinh;
                        sqlCommand.Parameters.Add("@TrinhDo", SqlDbType.NVarChar).Value = gv.TrinhDo;
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }

            return true;
        }
        public DataTable searchGV(string MaGV)
        {
            DataTable dt = new DataTable();
            connection = Connection.getSqlConnection();
            connection.Open();
            string sql = "select * from GiangVien where MaGV = '" + MaGV + "'";
            da = new SqlDataAdapter(sql, connection);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        public bool deleteGV(string GiangVien)
        {
            connection = Connection.getSqlConnection();
            string sql = "delete GiangVien where MaGV = @MaGV";
            try
            {
                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@MaGV", SqlDbType.NVarChar).Value = GiangVien;
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

