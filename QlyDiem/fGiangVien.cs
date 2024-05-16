﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyDiem
{
    public partial class fGiangVien : Form
    {
        GVModify gVModify;
        GiangVien giangVien;
        public fGiangVien()
        {
            InitializeComponent();
        }

        private void fGiangVien_Load(object sender, EventArgs e)
        {
            dgvSV.ReadOnly = true;
            gVModify = new GVModify();
            string sql = "select TenKhoa from Khoa";
            SqlConnection con = Connection.getSqlConnection();
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                // Thiết lập dữ liệu cho combo box
                cbbMaKhoa.DataSource = dataTable;
                cbbMaKhoa.DisplayMember = "TenKhoa"; // Tên cột bạn muốn hiển thị trong combo box
                cbbMaKhoa.ValueMember = "TenKhoa"; // Tên cột chứa giá trị thực sự trong combo box
            }
            con.Close();
            try
            {

                dgvSV.DataSource = gVModify.getAllGiangVien();
                dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSV.Columns[0].HeaderText = "Mã Giảng Viên";
                dgvSV.Columns[1].HeaderText = "Tên Giảng Viên";
                dgvSV.Columns[2].HeaderText = "Mã Khoa";
                dgvSV.Columns[3].HeaderText = "Ngày Sinh";
                dgvSV.Columns[4].HeaderText = "Quê Quán";
                dgvSV.Columns[5].HeaderText = "Giới Tính";
                dgvSV.Columns[6].HeaderText = "Trình Độ";
                dgvSV.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maGV = tbTimKiemTheoMa.Text;
            try
            {
                dgvSV.DataSource = gVModify.searchGV(maGV);
                dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSV.Columns[0].HeaderText = "Mã Giảng Viên";
                dgvSV.Columns[1].HeaderText = "Tên Giảng Viên";
                dgvSV.Columns[2].HeaderText = "Mã Khoa";
                dgvSV.Columns[3].HeaderText = "Ngày Sinh";
                dgvSV.Columns[4].HeaderText = "Quê Quán";
                dgvSV.Columns[5].HeaderText = "Giới Tính";
                dgvSV.Columns[6].HeaderText = "Trình Độ";
                dgvSV.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maGV = tbMaGV.Text;
            string tenGV = tbHoTen.Text;
            string ngaySinh = tbNgaysinh.Text;
            string tenKhoa = cbbMaKhoa.Text;
            string trinhDo = tbTrinhDo.Text;
            string queQuan = tbQueQuan.Text;
            string sql = "select MaKhoa from Khoa where TenKhoa = '" + tenKhoa + "'";
            SqlConnection con = Connection.getSqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            object oj = cmd.ExecuteScalar();
            con.Close();
            string maKhoa = oj.ToString(); 
            string gioiTinh;
            if (rdoNam.Checked)
            {
                gioiTinh = "Nam";
            }
            else
            {
                gioiTinh = "Nữ";
            }
            giangVien = new GiangVien(maGV, tenGV, maKhoa, ngaySinh, queQuan, gioiTinh, trinhDo);
            if (gVModify.insertGV(giangVien))
            {
                // Thêm thành công, cập nhật DataGridView
                dgvSV.DataSource = gVModify.getAllGiangVien();
            }
            else
            {
                MessageBox.Show("Lỗi Không thêm được ", "Lỗi");
            }

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbMaGV.Clear();
            tbHoTen.Clear();
            tbNgaysinh.Clear();
            tbTrinhDo.Clear();
            tbQueQuan.Clear();
        }
        private void btnTatCa_Click(object sender, EventArgs e)
        {
            dgvSV.ReadOnly = true;
            gVModify = new GVModify();
            try
            {
                dgvSV.DataSource = gVModify.getAllGiangVien();
                dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSV.Columns[0].HeaderText = "Mã Giảng Viên";
                dgvSV.Columns[1].HeaderText = "Tên Giảng Viên";
                dgvSV.Columns[2].HeaderText = "Mã Khoa";
                dgvSV.Columns[3].HeaderText = "Ngày Sinh";
                dgvSV.Columns[4].HeaderText = "Quê Quán";
                dgvSV.Columns[5].HeaderText = "Giới Tính";
                dgvSV.Columns[6].HeaderText = "Trình Độ";
                dgvSV.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSV = tbMaGV.Text;
            string tenSV = tbHoTen.Text;
            string maKhoa = cbbMaKhoa.Text;
            string queQuan = tbQueQuan.Text;
            string trinhDo = tbTrinhDo.Text;
            string sql = "select MaKhoa from Khoa where MaKhoa = '" + maKhoa + "'";
            SqlConnection con = Connection.getSqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            object oj = cmd.ExecuteScalar();
            con.Close();

            string gioiTinh;
            if (rdoNam.Checked)
            {
                gioiTinh = "Nam";
            }
            else
            {
                gioiTinh = "Nữ";
            }
            string ngaySinh = tbNgaysinh.Text;
            giangVien = new GiangVien(maSV, tenSV, maKhoa, ngaySinh, queQuan, gioiTinh, trinhDo);
            if (gVModify.updateGV(giangVien))
            {
                // sửa thành công, cập nhật DataGridView
                dgvSV.DataSource = gVModify.getAllGiangVien();
            }
            else
            {
                MessageBox.Show("Lỗi Không sửa được ", "Lỗi");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string gv = tbMaGV.Text;
            if (gVModify.deleteGV(gv))
            {
                dgvSV.DataSource = gVModify.getAllGiangVien();
            }
            else
            {
                MessageBox.Show("Lỗi Không xóa được ", "Lỗi");
            }
        }
        private void label20_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        private void label15_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }
        private void label18_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
        }

        private void label19_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }
    }
}
