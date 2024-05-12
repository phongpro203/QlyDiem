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

        private void fMonHoc_Load(object sender, EventArgs e)
        {
            dgvMH.ReadOnly = true;
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
            try
            {
                soTinChi = int.Parse(tbSoTC.Text);
                MonHoc = new MonHoc(maMon, tenMon, soTinChi);
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn phải nhập số nguyên");
                return;
            }
            if (mHModify.insert(MonHoc))
            {
                dgvMH.DataSource = mHModify.getAllMonHoc();
            }
            else
            {
                MessageBox.Show("Lỗi Không thêm được ", "Lỗi");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbMaMon.Clear();
            tbTenMon.Clear();
            tbSoTC.Clear();
            tbMaMon.Focus();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoMa.Clear();
            fMonHoc_Load(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maMon = tbTimKiemTheoMa.Text;
            try
            {
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
            try
            {
                soTinChi = int.Parse(tbSoTC.Text);
                MonHoc = new MonHoc(maMon, tenMon, soTinChi);
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn phải nhập số nguyên");
                return;
            }
            if (mHModify.update(MonHoc))
            {
                dgvMH.DataSource = mHModify.getAllMonHoc();
            }
            else
            {
                MessageBox.Show("Lỗi Không sửa được ", "Lỗi");
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maMon = tbMaMon.Text;
            if (mHModify.delete(maMon))
            {
                dgvMH.DataSource = mHModify.getAllMonHoc();
            }
            else
            {
                MessageBox.Show("Lỗi Không xóa được ", "Lỗi");
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
        }
    }
}
