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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maSV = tbTimKiemTheoMa.Text;
            try
            {
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

        private void btnThem_Click(object sender, EventArgs e)
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
            con.Close();
           
            string maLop = oj.ToString();
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
  
            sinhVien = new SinhVien(maSV, tenSV, queQuan, tenLop, maLop ,ngaySinh, gioiTinh);
            if (sVModify.insertSV(sinhVien))
            {
                // Thêm thành công, cập nhật DataGridView
                dgvSV.DataSource = sVModify.getAllSinhvien();
            }
            else
            {
                MessageBox.Show("Lỗi Không thêm được ", "Lỗi");
            }


        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbMaSV.Clear();
            tbHoTen.Clear();
            tbQueQuan.Clear();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            dgvSV.ReadOnly = true;
            sVModify = new SVModify();
            try
            {
                dgvSV.DataSource = sVModify.getAllSinhvien();
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

        private void btnSua_Click(object sender, EventArgs e)
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
            con.Close();

            string maLop = oj.ToString();
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
            sinhVien = new SinhVien(maSV, tenSV, queQuan, tenLop, maLop, ngaySinh, gioiTinh);
            if (sVModify.update(sinhVien))
            {
                // sửa thành công, cập nhật DataGridView
                dgvSV.DataSource = sVModify.getAllSinhvien();
            }
            else
            {
                MessageBox.Show("Lỗi Không sửa được ", "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sv = tbMaSV.Text;
            if (sVModify.delete(sv))
            {
                dgvSV.DataSource = sVModify.getAllSinhvien();
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
    }
}
