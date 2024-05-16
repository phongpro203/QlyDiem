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
            dgvSV.ReadOnly = true;
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
                cbbMaKhoa.DataSource = dataTable;
                cbbMaKhoa.DisplayMember = "TenKhoa"; // Tên cột bạn muốn hiển thị trong combo box
                cbbMaKhoa.ValueMember = "TenKhoa"; // Tên cột chứa giá trị thực sự trong combo box
            }
            con.Close();
            try
            {

                dgvSV.DataSource = lopModify.getAllopHoc();
                dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSV.Columns[0].HeaderText = "Mã lớp";
                dgvSV.Columns[1].HeaderText = "Tên lớp";
                dgvSV.Columns[2].HeaderText = "Khoa";
                dgvSV.ReadOnly = true;
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
            string khoa = cbbMaKhoa.Text;
            string sql = "select MaKhoa from Khoa where TenKhoa = N'" + khoa + "'";
            SqlConnection con = Connection.getSqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            object oj = cmd.ExecuteScalar();
            con.Close();
            string maKhoa = oj.ToString();
            lop = new Lop(maLop, tenLop, maKhoa);
            if (lopModify.update(lop))
            {
                // sửa thành công, cập nhật DataGridView
                dgvSV.DataSource = lopModify.getAllopHoc();
            }
            else
            {
                MessageBox.Show("Lỗi Không sửa được ", "Lỗi");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
