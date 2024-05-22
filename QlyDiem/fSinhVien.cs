using System;
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

        private void fSinhVien_Load(object sender, EventArgs e)                                     //load 
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
        private bool KiemTraLoiNhapLieu()                                                       //Kiểm tra nhập liệu
        {
            if (string.IsNullOrWhiteSpace(tbHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Sinh Viên", "Lỗi");
                return true;
            }
            if (string.IsNullOrWhiteSpace(cbbLop.Text))
            {
                MessageBox.Show("Vui lòng chọn Lớp", "Lỗi");
                return true;
            }
            if (string.IsNullOrWhiteSpace(tbQueQuan.Text))
            {
                MessageBox.Show("Vui lòng nhập Quê Quán", "Lỗi");
                return true;
            }
            if (string.IsNullOrWhiteSpace(tbNgaysinh.Text))
            {
                MessageBox.Show("Vui lòng nhập Ngày Sinh", "Lỗi");
                return true;
            }
            if (!rdoNam.Checked && !rdoNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn Giới Tính", "Lỗi");
                return true;
            }
            return false;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)                              //Nút tìm kiếm
        {
            string maSV = tbTimKiemTheoMa.Text;

            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng nhập Mã Sinh Viên để tìm kiếm", "Thông báo");
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
            string sql = "select MaLop from Lop where TenLop = @tenLop";
            SqlConnection con = null;
            SqlCommand cmd = null;
            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng nhập Mã Sinh Viên để Thêm ", "Thông báo");
                return;
            }
            DataTable result = sVModify.search(maSV);

            if (result.Rows.Count != 0)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại ", "Thông báo");
                return;
            }
            else if (KiemTraLoiNhapLieu())
            {
                return;
            }
            try
            {
                con = Connection.getSqlConnection();
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tenLop", tenLop);
                object oj = cmd.ExecuteScalar();
                string maLop = oj?.ToString(); // Sử dụng toán tử null-conditional để tránh lỗi NullReferenceException
                string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                string ngaySinh = tbNgaysinh.Text;

                SinhVien sinhVien = new SinhVien(maSV, tenSV, queQuan, tenLop, maLop, ngaySinh, gioiTinh);
                if (sVModify.insertSV(sinhVien))
                {
                    // Thêm thành công, cập nhật DataGridView
                    dgvSV.DataSource = sVModify.getAllSinhvien();
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
            btnRefresh_Click(sender, e);
        }

        
        private void btnSua_Click(object sender, EventArgs e)                                   //Nút sửa
        {

            string maSV = tbMaSV.Text;
            string tenSV = tbHoTen.Text;
            string tenLop = cbbLop.Text;
            string queQuan = tbQueQuan.Text;
            string sql = "select MaLop from Lop where TenLop = '" + tenLop + "'";
            SqlConnection con = Connection.getSqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            object oj = cmd.ExecuteScalar();
            string maLop = oj?.ToString(); // Sử dụng toán tử null-conditional để tránh lỗi NullReferenceException
            string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
            string ngaySinh = tbNgaysinh.Text;
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
                }else if (KiemTraLoiNhapLieu())
                {
                    return;
                }
                else if (sVModify.update(sinhVien))
                {
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
            btnRefresh_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)                                   //Nút xóa
        {
            string maSV = tbMaSV.Text;

            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng nhập Mã Sinh Viên để xóa ", "Thông báo");
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
            tbMaSV.Clear();
            tbHoTen.Clear();
            tbQueQuan.Clear();
        }

        private void btnTatCa_Click(object sender, EventArgs e)                                 //Nút tất cả
        {
            tbTimKiemTheoMa.Clear();
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

        private void fSinhVien_Activated(object sender, EventArgs e)
        {
            fSinhVien_Load(sender, e);
        }
    }
}
