using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QlyDiem
{
    public partial class fMonHoc : Form
    {
        MHModify mHModify;
        MonHoc MonHoc;
        public fMonHoc()
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
        private void fMonHoc_Load(object sender, EventArgs e)
        {
            mHModify = new MHModify();
            try
            {
                dgvMH.DataSource = mHModify.getAllMonHoc();
                dgvMH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvMH.Columns[0].HeaderText = "Mã Môn";
                dgvMH.Columns[1].HeaderText = "Tên Môn";
                dgvMH.Columns[2].HeaderText = "Số tín chỉ";
                dgvMH.ReadOnly = true;
            }
            catch(Exception ex) {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
            }
        }

        private void tbTimKiemTheoTen_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoMa.ForeColor = Color.Black;
            tbTimKiemTheoMa.Text = "";
        }

        private void dgvMH_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maMon = tbMaMon.Text;
            string tenMon = tbTenMon.Text;
            int soTinChi;
            if (maMon == "" || tenMon == "" || tbSoTC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }
            try
            {
                soTinChi = int.Parse(tbSoTC.Text);
                MonHoc = new MonHoc(maMon, tenMon, soTinChi);
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn phải nhập số nguyên", "Thông báo");
                return;
            }
            if (mHModify.insert(MonHoc))
            {
                dgvMH.DataSource = mHModify.getAllMonHoc();
                MessageBox.Show("Thêm thành công", "Thông báo");

            }
            else
            {
                MessageBox.Show("Lỗi Không thêm được ", "Lỗi");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoMa.Text = "Nhập mã môn cần tìm";
            tbMaMon.Clear();
            tbTenMon.Clear();
            tbSoTC.Clear();
            tbMaMon.Focus();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoMa.Text = "Nhập mã môn cần tìm";
            fMonHoc_Load(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maMon = tbTimKiemTheoMa.Text;
            string macdinh = "Nhập mã môn cần tìm";
            if (maMon == macdinh || maMon == "")
            {
                MessageBox.Show("Vui lòng nhập mã môn", "Thông báo");
                return;
            }
            try
            {
                DataTable result = mHModify.search(maMon);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo");
                    return;
                }
                dgvMH.DataSource = mHModify.search(maMon);
                dgvMH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvMH.Columns[0].HeaderText = "Mã Môn";
                dgvMH.Columns[1].HeaderText = "Tên Môn";
                dgvMH.Columns[2].HeaderText = "Số tín chỉ";
                dgvMH.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maMon = tbMaMon.Text;
            string tenMon = tbTenMon.Text;
            int soTinChi;
            if (maMon == "" || tenMon == "" || tbSoTC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }
            try
            {
                soTinChi = int.Parse(tbSoTC.Text);
                MonHoc = new MonHoc(maMon, tenMon, soTinChi);
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn phải nhập số nguyên", "Thông báo");
                return;
            }
            DataTable result = mHModify.search(maMon);

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu để sửa ", "Thông báo");
                return;
            }
            if (mHModify.update(MonHoc))
            {
                MessageBox.Show("Sửa thành công.", "Thông báo");
                dgvMH.DataSource = mHModify.getAllMonHoc();
            }
            else
            {
                MessageBox.Show("Lỗi Không sửa được ", "Lỗi");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maMon = tbMaMon.Text;
            if (maMon == "")
            {
                MessageBox.Show("Bạn chưa nhập mã môn!", "Thông báo");
                return;
            }
            DialogResult tl = MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Cancel || tl == DialogResult.No)
            {
                return;
            }
            DataTable result = mHModify.search(maMon);

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu để xóa", "Thông báo");
                return;
            }
            if (mHModify.delete(maMon))
            {
                dgvMH.DataSource = mHModify.getAllMonHoc();
                MessageBox.Show("Xóa thành công", "Thông báo");
                btnRefresh_Click(sender, e);
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


        private void label19_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
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

        private void tbTimKiemTheoMa_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoMa.Clear();
        }

        private void dgvMH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvMH.Rows[e.RowIndex];
            tbMaMon.Text = Convert.ToString(row.Cells["MaMon"].Value);
            tbTenMon.Text = Convert.ToString(row.Cells["TenMon"].Value);
            tbSoTC.Text = Convert.ToString(row.Cells["SoTinChi"].Value);
        }
    }
}
