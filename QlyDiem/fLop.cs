using System;
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
    public partial class fLop : Form
    {
        Lop lop;
        LopModify lopModify;
        public fLop()
        {
            InitializeComponent();
        }

        private void fLop_Load(object sender, EventArgs e)
        {
            dgvLop.ReadOnly = true;
            lopModify = new LopModify();
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
                cbbKhoa.DataSource = dataTable;
                cbbKhoa.DisplayMember = "TenKhoa"; // Tên cột bạn muốn hiển thị trong combo box
                cbbKhoa.ValueMember = "TenKhoa"; // Tên cột chứa giá trị thực sự trong combo box
            }
            con.Close();
            try
            {

                dgvLop.DataSource = lopModify.getAllopHoc();
                dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLop.Columns[0].HeaderText = "Mã lớp";
                dgvLop.Columns[1].HeaderText = "Tên lớp";
                dgvLop.Columns[2].HeaderText = "Khoa";
                dgvLop.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbMaLop.Clear();
            tbTenLop.Clear();
            tbMaLop.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maLop = tbMaLop.Text;
            string tenLop = tbTenLop.Text;
            string khoa = cbbKhoa.Text;
            string sql = "SELECT MaKhoa FROM Khoa WHERE TenKhoa = @TenKhoa";
            string maKhoa = null;

            using (SqlConnection con = Connection.getSqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@TenKhoa",khoa);

                    con.Open();

                    object oj = cmd.ExecuteScalar();

                    if (oj != null)
                    {
                        maKhoa = oj.ToString();
                    }
                }
            }
            lop = new Lop(maLop, tenLop, maKhoa);
            if (lopModify.update(lop))
            {
                // sửa thành công, cập nhật DataGridView
                dgvLop.DataSource = lopModify.getAllopHoc();
            }
            else
            {
                MessageBox.Show("Lỗi Không sửa được ", "Lỗi");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLop = tbMaLop.Text;
            string tenLop = tbTenLop.Text;
            string khoa = cbbKhoa.Text;
            string sql = "SELECT MaKhoa FROM Khoa WHERE TenKhoa = @TenKhoa";
            string maKhoa = null;

            using (SqlConnection con = Connection.getSqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@TenKhoa", khoa);

                    con.Open();

                    object oj = cmd.ExecuteScalar();

                    if (oj != null)
                    {
                        maKhoa = oj.ToString();
                    }
                }
            }
            lop = new Lop(maLop, tenLop, maKhoa);
            if (lopModify.insertlop(lop))
            {
                // sửa thành công, cập nhật DataGridView
                dgvLop.DataSource = lopModify.getAllopHoc();
            }
            else
            {
                MessageBox.Show("Lỗi Không thêm được ", "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ml = tbMaLop.Text;
            if (lopModify.delete(ml))
            {
                dgvLop.DataSource = lopModify.getAllopHoc();
            }
            else
            {
                MessageBox.Show("Lỗi Không xóa được ", "Lỗi");
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
        }

        private void label19_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
        }

        private void label20_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void fLop_Activated(object sender, EventArgs e)
        {
            fLop_Load(sender, e);
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvLop.Rows[e.RowIndex];
            tbMaLop.Text = Convert.ToString(row.Cells["MaLop"].Value);
            tbTenLop.Text = Convert.ToString(row.Cells["TenLop"].Value);
            cbbKhoa.Text = Convert.ToString(row.Cells["TenKhoa"].Value);
        }

        private void dgvLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvLop.Rows[e.RowIndex];
            tbMaLop.Text = Convert.ToString(row.Cells["MaLop"].Value);
            tbTenLop.Text = Convert.ToString(row.Cells["TenLop"].Value);
            cbbKhoa.Text = Convert.ToString(row.Cells["TenKhoa"].Value);
        }

        private void tbTimKiemTheoTen_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoTen.Text = "";
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            fLop_Load(sender, e);
            tbTimKiemTheoTen.Text = "Nhập mã lớp";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
