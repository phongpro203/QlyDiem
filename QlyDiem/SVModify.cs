using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyDiem
{
    internal class SVModify
    {
        SqlCommand sqlCommand = null;
        SqlConnection connection = null;
        SqlDataAdapter da = null;
        public DataTable getAllSinhvien()
        {
            DataTable dt = new DataTable();

            connection = Connection.getSqlConnection();
            connection.Open();
            string sql = "select SinhVien.MaSV,SinhVien.TenSV,Lop.TenLop,SinhVien.NgaySinh,SinhVien.QueQuan,SinhVien.GioiTinh " +
                         "from SinhVien,Lop where SinhVien.MaLop=Lop.MaLop";
            da = new SqlDataAdapter(sql, connection);
            da.Fill(dt);
            connection.Close();
            return dt;
        }

        public bool insertSV(SinhVien sv)
        {
            connection = Connection.getSqlConnection();
            string sql = "insert into SinhVien (MaSV, TenSV, MaLop, NgaySinh,QueQuan, GioiTinh) values (@MaSV, @TenSV, @MaLop, @NgaySinh, @QueQuan, @GioiTinh)";
            try
            {
                
                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSV;
                sqlCommand.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;          
                sqlCommand.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = sv.QueQuan;
                sqlCommand.Parameters.Add("@MaLop", SqlDbType.NVarChar).Value = sv.MaLop;
                sqlCommand.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = sv.NgaySinh;
                sqlCommand.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = sv.GioiTinh;
                sqlCommand.ExecuteNonQuery();//thuc thi lenh truy van

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627) // Mã lỗi cho "Nhập trùng khóa"
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại trong cơ sở dữ liệu.");
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
        public bool update(SinhVien sv)
        {
            connection = Connection.getSqlConnection();
            string sql = "update SinhVien set TenSV = @TenSV, QueQuan = @QueQuan, MaLop = @MaLop, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh where MaSV = @MaSV";
            try
            {
                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSV;
                sqlCommand.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                sqlCommand.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = sv.QueQuan;
                sqlCommand.Parameters.Add("@MaLop", SqlDbType.NVarChar).Value = sv.MaLop;
                sqlCommand.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = sv.NgaySinh;
                sqlCommand.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = sv.GioiTinh;
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
        public DataTable search(string MaSV)
        {
            DataTable dt = new DataTable();
            connection = Connection.getSqlConnection();
            connection.Open();
            string sql = "select SinhVien.MaSV,SinhVien.TenSV,Lop.TenLop,SinhVien.NgaySinh,SinhVien.QueQuan,SinhVien.GioiTinh " +
                         "from SinhVien,Lop where SinhVien.MaLop=Lop.MaLop and SinhVien.MaSV = '" + MaSV + "'";
            da = new SqlDataAdapter(sql, connection);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        public bool delete(string SinhVien)
        {
            connection = Connection.getSqlConnection();
            string sql = "delete SinhVien where MaSV = @MaSV";
            try
            {
                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = SinhVien;
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
