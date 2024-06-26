﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QlyDiem
{
    public partial class fSinhVien : Form
    {
        SVModify sVModify;
        SinhVien sinhVien;
        public fSinhVien()
        {
            InitializeComponent();
        }
        public async Task LoadDataAsync()
        {
            await Task.Run(() =>
            {
                // Thực hiện các tác vụ tải dữ liệu nặng tại đây
                System.Threading.Thread.Sleep(2000); // Giả lập tải dữ liệu
            });
        }
        private void fSinhVien_Load(object sender, EventArgs e)                                    
        {
            dgvSV.ReadOnly = true;
            sVModify = new SVModify();
            string sql = "select TenLop from Lop";
            SqlConnection con = Connection.getSqlConnection();
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                // Thiết lập dữ liệu cho combo box
                cbbLop.DataSource = dataTable;
                cbbLop.DisplayMember = "TenLop"; // Tên cột bạn muốn hiển thị trong combo box
                cbbLop.ValueMember = "TenLop"; // Tên cột chứa giá trị thực sự trong combo box
            }
            con.Close();
            try
            {
                
                dgvSV.DataSource = sVModify.getAllSinhvien();
                dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSV.Columns[0].HeaderText = "Mã Sinh Viên";
                dgvSV.Columns[1].HeaderText = "Tên Sinh Viên";
                dgvSV.Columns[2].HeaderText = "Tên Lớp";
                dgvSV.Columns[3].HeaderText = "Ngày Sinh";
                dgvSV.Columns[4].HeaderText = "Quê Quán";
                dgvSV.Columns[5].HeaderText = "Giới Tính"; 
                dgvSV.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
            }
            
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)                              //Nút tìm kiếm
        {
            string maSV = tbTimKiemTheoMa.Text;
            if (maSV == "Nhập mã sinh viên" || maSV == "")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên", "Thông báo");
                return;
            }
            try
            {
                DataTable result = sVModify.search(maSV);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo");
                    return;
                }
                dgvSV.DataSource = sVModify.search(maSV);
                dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSV.Columns[0].HeaderText = "Mã Sinh Viên";
                dgvSV.Columns[1].HeaderText = "Tên Sinh Viên";
                dgvSV.Columns[2].HeaderText = "Mã Lóp";
                dgvSV.Columns[3].HeaderText = "Tên Lóp";
                dgvSV.Columns[3].HeaderText = "Ngày Sinh";
                dgvSV.Columns[4].HeaderText = "Quê Quán";
                dgvSV.Columns[5].HeaderText = "Giới Tính";
                dgvSV.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)                                  //Nút thêm
        {
            string maSV = tbMaSV.Text;
            string tenSV = tbHoTen.Text;
            string tenLop = cbbLop.Text;
            string queQuan = tbQueQuan.Text;
            string ngaySinh = tbNgaysinh.Text;
            string gioiTinh = rdoNam.Checked ? "Nam" : rdoNu.Checked ? "Nữ" : null;

            // check nhập liệu
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(tenSV) ||
                string.IsNullOrWhiteSpace(tenLop) || string.IsNullOrWhiteSpace(queQuan) ||
                string.IsNullOrWhiteSpace(ngaySinh) || gioiTinh == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
                return;
            }

            string sql = "select MaLop from Lop where TenLop = @tenLop";
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                con = Connection.getSqlConnection();
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tenLop", tenLop);
                object oj = cmd.ExecuteScalar();
                string maLop = oj?.ToString(); // Sử dụng toán tử null-conditional để tránh lỗi NullReferenceException

                SinhVien sinhVien = new SinhVien(maSV, tenSV, queQuan, tenLop, maLop, ngaySinh, gioiTinh);
                if (sVModify.insertSV(sinhVien))
                {
                    // Thêm thành công, cập nhật DataGridView
                    dgvSV.DataSource = sVModify.getAllSinhvien();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Lỗi không thêm được", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
            finally
            {
                con?.Close();
                cmd?.Dispose();
            }     
        }



        private void btnSua_Click(object sender, EventArgs e)                                   //Nút sửa
        {
            string maSV = tbMaSV.Text;
            string tenSV = tbHoTen.Text;
            string tenLop = cbbLop.Text;
            string queQuan = tbQueQuan.Text;
            string ngaySinh = tbNgaysinh.Text;
            string gioiTinh = rdoNam.Checked ? "Nam" : rdoNu.Checked ? "Nữ" : null;

            // check nhập liệu
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(tenSV) ||
                string.IsNullOrWhiteSpace(tenLop) || string.IsNullOrWhiteSpace(queQuan) ||
                string.IsNullOrWhiteSpace(ngaySinh) || gioiTinh == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
                return;
            }

            string sql = "select MaLop from Lop where TenLop = @tenLop";
            SqlConnection con = Connection.getSqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@tenLop", tenLop);
            object oj = cmd.ExecuteScalar();
            string maLop = oj?.ToString(); // Sử dụng toán tử null-conditional để tránh lỗi NullReferenceException

            sinhVien = new SinhVien(maSV, tenSV, queQuan, tenLop, maLop, ngaySinh, gioiTinh);

            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng nhập Mã Sinh Viên để sửa ", "Thông báo");
                return;
            }

            try
            {
                DataTable result = sVModify.search(maSV);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu để sửa ", "Thông báo");
                    return;
                }
                else if (sVModify.update(sinhVien))
                {
                    MessageBox.Show("Sửa thành công.", "Thông báo");
                    // sửa thành công, cập nhật DataGridView
                    dgvSV.DataSource = sVModify.getAllSinhvien();
                }
                else
                {
                    MessageBox.Show("Lỗi Không sửa được ", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)                                   //Nút xóa
        {
            string maSV = tbMaSV.Text;
            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng nhập Mã Sinh Viên để xóa ", "Thông báo");
                return;
            }
            DialogResult tl = MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Cancel || tl == DialogResult.No)
            {
                return;
            }
            try
            {
                DataTable result = sVModify.search(maSV);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu để xóa", "Thông báo");
                    return;
                }else if (sVModify.delete(maSV))
                {
                    dgvSV.DataSource = sVModify.getAllSinhvien();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Lỗi Không xóa được ", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
            
        }
        private void btnRefresh_Click(object sender, EventArgs e)                               //Nút làm mới
        {
            tbTimKiemTheoMa.Text = "Nhập mã sinh viên";
            tbMaSV.Clear();
            tbHoTen.Clear();
            tbQueQuan.Clear();
            tbMaSV.Focus();
        }

        private void btnTatCa_Click(object sender, EventArgs e)                                 //Nút tất cả
        {
            tbTimKiemTheoMa.Text = "Nhập mã sinh viên";
            tbMaSV.Clear();
            tbHoTen.Clear();
            tbQueQuan.Clear();
            fSinhVien_Load(sender, e);
            
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

        private void tbTimKiemTheoMa_Click_1(object sender, EventArgs e)
        {
            tbTimKiemTheoMa.Clear();
        }

        private void dgvSV_CellContentClick(object sender, DataGridViewCellEventArgs e)                 //cell click
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvSV.Rows[e.RowIndex];
            tbMaSV.Text = Convert.ToString(row.Cells["MaSV"].Value);
            tbHoTen.Text = Convert.ToString(row.Cells["TenSV"].Value);
            cbbLop.Text = Convert.ToString(row.Cells["TenLop"].Value);
            tbNgaysinh.Text = Convert.ToString(row.Cells["NgaySinh"].Value);
            tbQueQuan.Text = Convert.ToString(row.Cells["QueQuan"].Value);
            string gt;
            gt = dgvSV.CurrentRow.Cells["GioiTinh"].Value.ToString();
            if (gt == "Nam")
            {
                rdoNam.Checked = true;
            }
            if (gt == "Nữ")
            {
                rdoNu.Checked = true;
            }
        }
        private void fSinhVien_Activated_1(object sender, EventArgs e)
        {
            fSinhVien_Load(sender, e);
        }
    }
}
