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
    public partial class fGiangVien : Form
    {
        GVModify gVModify;
        public fGiangVien()
        {
            InitializeComponent();
        }
        DataTable dataTable;
        public async Task LoadDataAsync()
        {
            await Task.Run(() =>
            {
                // Thực hiện các tác vụ tải dữ liệu nặng tại đây
                System.Threading.Thread.Sleep(2000); // Giả lập tải dữ liệu
            });
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
            dataTable = new DataTable();
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
                dgvSV.Columns[2].HeaderText = "Tên Khoa";
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
            string macdinh = "Nhập mã giảng viên";
            string maGV = tbTimKiemTheoMa.Text;
            if (maGV == macdinh || maGV == "")
            {
                MessageBox.Show("Vui lòng nhập mã giảng viên", "Thông báo");
                return;
            }
            try
            {
                DataTable result = gVModify.searchGV(maGV);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo");
                    return;
                }
                dgvSV.DataSource = gVModify.searchGV(maGV);
                dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSV.Columns[0].HeaderText = "Mã Giảng Viên";
                dgvSV.Columns[1].HeaderText = "Tên Giảng Viên";
                dgvSV.Columns[2].HeaderText = "Tên Khoa";
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

            if (string.IsNullOrEmpty(maGV) || string.IsNullOrEmpty(tenGV) || string.IsNullOrEmpty(ngaySinh) || string.IsNullOrEmpty(tenKhoa) || string.IsNullOrEmpty(trinhDo) || string.IsNullOrEmpty(queQuan))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
            }
            else
            {
                string sql = "SELECT MaKhoa FROM Khoa WHERE TenKhoa = @TenKhoa";
                string maKhoa = null;

                using (SqlConnection con = Connection.getSqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@TenKhoa", tenKhoa);
                        con.Open();
                        object oj = cmd.ExecuteScalar();

                        if (oj != null)
                        {
                            maKhoa = oj.ToString();
                        }
                    }
                }

                if (maKhoa != null)
                {
                    string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";

                    GiangVien giangVien = new GiangVien(maGV, tenGV, maKhoa, ngaySinh, queQuan, gioiTinh, trinhDo);

                    if (gVModify.insertGV(giangVien))
                    {
                        dgvSV.DataSource = gVModify.getAllGiangVien();
                        MessageBox.Show("Thêm thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không thêm được giảng viên.", "Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Mã Khoa tương ứng với Tên Khoa đã chọn.", "Lỗi");
                }
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {

            tbTimKiemTheoMa.Text = "Nhập mã giảng viên";
            tbMaGV.Clear();
            tbHoTen.Clear();
            tbTrinhDo.Clear();
            tbQueQuan.Clear();
            tbMaGV.Focus();
        }
        private void btnTatCa_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoMa.Text = "Nhập mã giảng viên";
            dgvSV.ReadOnly = true;
            gVModify = new GVModify();
            try
            {
                dgvSV.DataSource = gVModify.getAllGiangVien();
                dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSV.Columns[0].HeaderText = "Mã Giảng Viên";
                dgvSV.Columns[1].HeaderText = "Tên Giảng Viên";
                dgvSV.Columns[2].HeaderText = "Tên Khoa";
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
            string maGV = tbMaGV.Text;
            string tenGV = tbHoTen.Text;
            string ngaySinh = tbNgaysinh.Text;
            string tenKhoa = cbbMaKhoa.Text;
            string trinhDo = tbTrinhDo.Text;
            string queQuan = tbQueQuan.Text;

            if (string.IsNullOrEmpty(maGV) || string.IsNullOrEmpty(tenGV) || string.IsNullOrEmpty(ngaySinh) || string.IsNullOrEmpty(tenKhoa) || string.IsNullOrEmpty(trinhDo) || string.IsNullOrEmpty(queQuan))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
            }
            else
            {
                DataTable result = gVModify.searchGV(maGV);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu để sửa ", "Thông báo");
                    return;
                }
                string sql = "SELECT MaKhoa FROM Khoa WHERE TenKhoa = @TenKhoa";
                string maKhoa = null;

                using (SqlConnection con = Connection.getSqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@TenKhoa", tenKhoa);
                        con.Open();
                        object oj = cmd.ExecuteScalar();

                        if (oj != null)
                        {
                            maKhoa = oj.ToString();
                        }
                    }
                }

                if (maKhoa != null)
                {
                    string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";

                    GiangVien giangVien = new GiangVien(maGV, tenGV, maKhoa, ngaySinh, queQuan, gioiTinh, trinhDo);

                    if (gVModify.updateGV(giangVien))
                    {
                        dgvSV.DataSource = gVModify.getAllGiangVien();
                        MessageBox.Show("Sửa thành công.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không sửa được giảng viên.", "Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Mã Khoa tương ứng với Tên Khoa đã chọn.", "Lỗi");
                }
            }
        }            
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string gv = tbMaGV.Text;
            
            if (string.IsNullOrWhiteSpace(gv))
            {
                MessageBox.Show("Vui lòng nhập mã giảng viên để xoá", "Thông báo");
                return;
            }
            DialogResult tl = MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Cancel || tl == DialogResult.No)
            {
                return;
            }

            DataTable result = gVModify.searchGV(gv);

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu để xóa", "Thông báo");
                return;
            }
            if (gVModify.deleteGV(gv))
            {
                dgvSV.DataSource = gVModify.getAllGiangVien();
                MessageBox.Show("Xóa thành công", "Thông báo");
                btnRefresh_Click(sender, e);

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

        private void dgvSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvSV.Rows[e.RowIndex];
            tbMaGV.Text = Convert.ToString(row.Cells["MaGV"].Value);
            tbHoTen.Text = Convert.ToString(row.Cells["TenGV"].Value);
            tbNgaysinh.Text = Convert.ToString(row.Cells["NgaySinh"].Value);
            tbQueQuan.Text = Convert.ToString(row.Cells["QueQuan"].Value);
            cbbMaKhoa.Text = Convert.ToString(row.Cells["TenKhoa"].Value);
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
            tbTrinhDo.Text = Convert.ToString(row.Cells["TrinhDo"].Value);
        }

        private void tbTimKiemTheoMa_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoMa.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BindingContext[dataTable].Position += 1;
        }
    }
}
