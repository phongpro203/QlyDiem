using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlyDiem
{
    internal class DiemModify
    {
        SqlCommand sqlCommand = null;
        SqlConnection connection = null;
        SqlDataAdapter da = null;
        public DataTable getAllDiem()
        {
            DataTable dt = new DataTable();

            connection = Connection.getSqlConnection();
            connection.Open();
            string sql = "select BangDiem.MaSV,SinhVien.TenSV,MonHoc.MaMon,MonHoc.TenMon,BangDiem.HocKy,BangDiem.DiemThuongXuyen,BangDiem.DiemThi from BangDiem,SinhVien,MonHoc where BangDiem.MaSV=SinhVien.MaSV and BangDiem.MaMon=MonHoc.MaMon";
            da = new SqlDataAdapter(sql, connection);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        public DataTable search(string MaSV)
        {
            DataTable dt = new DataTable();
            connection = Connection.getSqlConnection();
            connection.Open();
            string sql = "select BangDiem.MaSV,SinhVien.TenSV,MonHoc.MaMon,MonHoc.TenMon,BangDiem.HocKy,BangDiem.DiemThuongXuyen,BangDiem.DiemThi " +
                         "from BangDiem,SinhVien,MonHoc where BangDiem.MaMon = MonHoc.MaMon and BangDiem.MaSV=SinhVien.MaSV and BangDiem.MaSV = '" + MaSV + "'";
            da = new SqlDataAdapter(sql, connection);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        public bool insertDiem(Diem diem)
        {
            connection = Connection.getSqlConnection();
            string sql = "insert into BangDiem (MaSV, MaMon, HocKy, DiemThi,DiemThuongXuyen) values (@MaSV, @MaMon, @HocKy, @DiemThi, @DiemThuongXuyen)";
            try
            {

                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = diem.MaSV;
                sqlCommand.Parameters.Add("@MaMon", SqlDbType.NVarChar).Value = diem.MaMon;
                sqlCommand.Parameters.Add("@HocKy", SqlDbType.Int).Value = diem.HocKy;
                sqlCommand.Parameters.Add("@DiemThi", SqlDbType.Float).Value = diem.DiemThi;
                sqlCommand.Parameters.Add("@DiemThuongXuyen", SqlDbType.Float).Value = diem.DiemTX;
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
        public bool SVTonTai(string maSV)
        {
            // Implement the SQL query to check if the student exists
            string query = "select count(*) from SinhVien where MaSV = @MaSV";
            using (SqlConnection con = Connection.getSqlConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool MonHocTonTai(string maMon)
        {
            // Implement the SQL query to check if the subject exists
            string query = "select count(*) from MonHoc where MaMon = @MaMon";
            using (SqlConnection con = Connection.getSqlConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@MaMon", maMon);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool delete(string maSV, string maMon)
        {
            using (SqlConnection connection = Connection.getSqlConnection())
            {
                string sql = "DELETE FROM BangDiem WHERE MaSV = @MaSV AND MaMon = @MaMon";
                try
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = maSV;
                        sqlCommand.Parameters.Add("@MaMon", SqlDbType.NVarChar).Value = maMon;
                        int rowsAffected = sqlCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return true; //xoá thành công
                        }
                        else
                        {
                            return false; 
                        }
                    }
                }
                catch
                {
                    return false; // lỗi
                }
            }
        }

        public bool update(Diem diem)
        {
            connection = Connection.getSqlConnection();
            string sql = "update BangDiem set HocKy = @HocKy, DiemThi = @DiemThi, DiemThuongXuyen = @DiemThuongXuyen where MaSV = @MaSV and MaMon = @MaMon";
            try
            {
                connection.Open();
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = diem.MaSV;
                sqlCommand.Parameters.Add("@MaMon", SqlDbType.NVarChar).Value = diem.MaMon;
                sqlCommand.Parameters.Add("@HocKy", SqlDbType.Int).Value = diem.HocKy;
                sqlCommand.Parameters.Add("@DiemThi", SqlDbType.Float).Value = diem.DiemThi;
                sqlCommand.Parameters.Add("@DiemThuongXuyen", SqlDbType.Float).Value = diem.DiemTX;
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
