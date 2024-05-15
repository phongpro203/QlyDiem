﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string sql = "select *from SinhVien";
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
            string sql = "select * from SinhVien where MaSV = '" + MaSV + "'";
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
