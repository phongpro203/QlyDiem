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
    public partial class fDiem : Form
    {
        DiemModify diemModify;
        Diem diem;
        public fDiem()
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
        private void fDiem_Load(object sender, EventArgs e)                                     
        {
            dgvDiem.ReadOnly = true;
            diemModify = new DiemModify();
            try
            {
                dgvDiem.DataSource = diemModify.getAllDiem();
                dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDiem.Columns[0].HeaderText = "MSV";
                dgvDiem.Columns[1].HeaderText = "Tên sinh viên";
                dgvDiem.Columns[2].HeaderText = "Mã môn";
                dgvDiem.Columns[3].HeaderText = "Tên môn";
                dgvDiem.Columns[4].HeaderText = "Học kỳ";
                dgvDiem.Columns[5].HeaderText = "Điểm thường xuyên";
                dgvDiem.Columns[6].HeaderText = "Điểm thi";
                dgvDiem.ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
            }

        }

        private void tbMaSV_TextChanged(object sender, EventArgs e)
        {
            if (tbMaSV.Text.Length > 0)
            {
                LoadTenSV(tbMaSV.Text);
            }
        }
        private void LoadTenSV(string studentId)
        {
            string query = "select TenSV from SinhVien where MaSV = @MaSV";
            SqlConnection con = Connection.getSqlConnection();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@MaSV", studentId);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    tbHoTen.Text = reader["TenSV"].ToString();
                }
                else
                {
                    tbHoTen.Text = "Không tìm thấy";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void tbMaMon_TextChanged(object sender, EventArgs e)
        {
            if (tbMaMon.Text.Length > 0)
            {
                LoadTenMon(tbMaMon.Text);
            }
        }
        private void LoadTenMon(string studentId)
        {
            string query = "SELECT TenMon FROM MonHoc WHERE MaMon = @MaMon";
            SqlConnection con = Connection.getSqlConnection();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@MaMon", studentId);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    tbTenMon.Text = reader["TenMon"].ToString();
                }
                else
                {
                    tbTenMon.Text = "Không tìm thấy";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)                   //Nút làm mới
        {
            tbTimKiemTheoMa.Text = "Nhập mã sinh viên";
            tbHoTen.Clear();
            tbMaMon.Clear();
            tbDT.Clear();
            tbDTX.Clear();
            tbMaSV.Clear();
            tbTenMon.Clear();
            tbMaSV.Focus();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void tbTimKiemTheoMa_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoMa.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)                                   //Nút Tìm Kiếm
        {
            string maSV = tbTimKiemTheoMa.Text;

            if (maSV == "Nhập mã sinh viên" || maSV == "")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên", "Thông báo");
                return;
            }
            try
            {
                DataTable result = diemModify.search(maSV);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo");
                    return;
                }
                dgvDiem.DataSource = diemModify.search(maSV);
                dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDiem.Columns[0].HeaderText = "MSV";
                dgvDiem.Columns[1].HeaderText = "Tên sinh viên";
                dgvDiem.Columns[2].HeaderText = "Mã môn";
                dgvDiem.Columns[3].HeaderText = "Tên môn";
                dgvDiem.Columns[4].HeaderText = "Học kỳ";
                dgvDiem.Columns[5].HeaderText = "Điểm thường xuyên";
                dgvDiem.Columns[6].HeaderText = "Điểm thi";
                dgvDiem.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)                                 //Nut hiển thị tất cả
        {
            tbTimKiemTheoMa.Text = "Nhập mã sinh viên";
            tbHoTen.Clear();
            tbMaMon.Clear();
            tbDT.Clear();
            tbDTX.Clear();
            tbMaSV.Clear();
            tbTenMon.Clear();
            fDiem_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)                      //Nút Thêm
        {
            string maSV = tbMaSV.Text;
            string maMon = tbMaMon.Text;
            string hocKy = cbbHK.Text;
            float diemThi;
            float diemTK;
            // check nhập liệu
            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maMon) || 
                string.IsNullOrEmpty(hocKy)|| string.IsNullOrEmpty(tbDT.Text) || 
                string.IsNullOrEmpty(tbDTX.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
                return;
            }

            if (!float.TryParse(tbDT.Text, out diemThi) || diemThi < 0 || diemThi > 10)
            {
                MessageBox.Show("Điểm thi phải là số thực từ 0 đến 10", "Lỗi Định Dạng");
                return;
            }

            if (!float.TryParse(tbDTX.Text, out diemTK) || diemTK < 0 || diemTK > 10)
            {
                MessageBox.Show("Điểm thường xuyên phải là số thực từ 0 đến 10", "Lỗi Định Dạng");
                return;
            }
  

            if (!diemModify.SVTonTai(maSV))
            {
                MessageBox.Show("Sinh viên không tồn tại", "Lỗi");
                return;
            }

            if (!diemModify.MonHocTonTai(maMon))
            {
                MessageBox.Show("Môn học không tồn tại", "Lỗi");
                return;
            }

            try
            {
                Diem diem = new Diem(maSV, maMon, hocKy, diemThi, diemTK);

                if (diemModify.insertDiem(diem))
                {
                    dgvDiem.DataSource = diemModify.getAllDiem();
                    MessageBox.Show("Thêm thành công", "Thông báo");

                }
                else
                {
                    MessageBox.Show("Lỗi không thêm được", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)                               //Nút Xoá
        {
            string maSV = tbMaSV.Text;
            string maMon = tbMaMon.Text;

            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(maMon))
            {
                MessageBox.Show("Vui lòng nhập cả Mã Sinh Viên và Mã Môn để xóa", "Thông báo");
                return;
            }

            DialogResult tl = MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Cancel || tl == DialogResult.No)
            {
                return;
            }

            if (diemModify.delete(maSV, maMon))
            {
                dgvDiem.DataSource = diemModify.getAllDiem(); // làm mới data grid view
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Không thể xóa. Hãy kiểm tra Mã Sinh Viên và Mã Môn.", "Lỗi");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
        }

        private void label19_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)                           //Nút Sửa
        {
            string maSV = tbMaSV.Text;
            string maMon = tbMaMon.Text;
            string hocKy = cbbHK.Text;
            float diemThi;
            float diemTK;
            // check nhập liệu
            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maMon) || 
                string.IsNullOrEmpty(hocKy) || string.IsNullOrEmpty(tbDT.Text) || 
                string.IsNullOrEmpty(tbDTX.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
                return;
            }

            if (!float.TryParse(tbDT.Text, out diemThi) || diemThi < 0 || diemThi > 10)
            {
                MessageBox.Show("Điểm thi phải là số thực từ 0 đến 10", "Lỗi Định Dạng");
                return;
            }

            if (!float.TryParse(tbDTX.Text, out diemTK) || diemTK < 0 || diemTK > 10)
            {
                MessageBox.Show("Điểm thường xuyên phải là số thực từ 0 đến 10", "Lỗi Định Dạng");
                return;
            }


            if (!diemModify.SVTonTai(maSV))
            {
                MessageBox.Show("Không tìm thấy sinh viên", "Lỗi");
                return;
            }

            if (!diemModify.MonHocTonTai(maMon))
            {
                MessageBox.Show("Không tìm thấy môn học", "Lỗi");
                return;
            }
            try
            {
                Diem diem = new Diem(maSV, maMon, hocKy, diemThi, diemTK);

                if (diemModify.update(diem))
                {
                    dgvDiem.DataSource = diemModify.getAllDiem();
                    MessageBox.Show("Sửa thành công.", "Thông báo");

                }
                else
                {
                    MessageBox.Show("Lỗi không sửa được", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void label18_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void dgvDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)           //cell click
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvDiem.Rows[e.RowIndex];
            tbMaSV.Text = Convert.ToString(row.Cells["MaSV"].Value);
            tbMaMon.Text = Convert.ToString(row.Cells["MaMon"].Value);
            tbDT.Text = Convert.ToString(row.Cells["DiemThi"].Value);
            cbbHK.Text = Convert.ToString(row.Cells["HocKy"].Value);
            tbDTX.Text = Convert.ToString(row.Cells["DiemThuongXuyen"].Value);
        }

        private void fDiem_Activated(object sender, EventArgs e)
        {
            fDiem_Load(sender, e);
        }
    }
}
