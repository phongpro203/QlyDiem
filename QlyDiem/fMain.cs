using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyDiem
{
    public partial class fMain : Form
    {
        // Khởi tạo các form
        fDiem fDiem;
        fSinhVien fSinhVien;
        fGiangVien fGiangVien;
        fLop fLop;
        fMonHoc fMonHoc;
        fThongKe fThongKe;
        private bool isExiting = false;

        public fMain()
        {
            InitializeComponent();
            // Khởi tạo các form
            fDiem = new fDiem();
            fSinhVien = new fSinhVien();
            fGiangVien = new fGiangVien();
            fLop = new fLop();
            fMonHoc = new fMonHoc();
            fThongKe = new fThongKe();
            // Thiết lập các form con
            InitializeChildForm(fDiem);
            InitializeChildForm(fSinhVien);
            InitializeChildForm(fGiangVien);
            InitializeChildForm(fLop);
            InitializeChildForm(fMonHoc);
            InitializeChildForm(fThongKe);
        }

        private void InitializeChildForm(Form form)
        {
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Hide();
            form.Activated += async (sender, e) => await LoadDataAsync(form);
        }

        private async Task LoadDataAsync(Form form)
        {
            ShowLoadingIndicator(form);
            await Task.Run(() => {
                // Thực hiện các tác vụ nặng tại đây
                // Giả lập tải dữ liệu
                System.Threading.Thread.Sleep(2000); // Thay thế bằng mã tải dữ liệu thực tế
            });
            HideLoadingIndicator(form);
        }

        private void ShowLoadingIndicator(Form form)
        {
            form.Cursor = Cursors.WaitCursor;
        }

        private void HideLoadingIndicator(Form form)
        {
            form.Cursor = Cursors.Default;
        }

        private void HideAllForms()
        {
            fDiem.Hide();
            fSinhVien.Hide();
            fGiangVien.Hide();
            fLop.Hide();
            fMonHoc.Hide();
            fThongKe.Hide();
        }
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllForms();
        }
        private async void ShowFormAsync(Form form)
        {
            HideAllForms();
            form.Show();
            form.BringToFront();
            await LoadDataAsync(form);
        }

        private void lbSV_Click(object sender, EventArgs e)
        {
            ShowFormAsync(fSinhVien);
        }

        private void lbDiem_Click(object sender, EventArgs e)
        {
            ShowFormAsync(fDiem);
        }

        private void lbGV_Click(object sender, EventArgs e)
        {
            ShowFormAsync(fGiangVien);
        }

        private void lbLTC_Click(object sender, EventArgs e)
        {
            ShowFormAsync(fLop);
        }

        private void lbMH_Click(object sender, EventArgs e)
        {
            ShowFormAsync(fMonHoc);
        }

        private void ThongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormAsync(fThongKe);
        }

        private void trangChuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllForms();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HideAllForms();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isExiting = true;
            DialogResult tl = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExiting)
            {
                DialogResult tl = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    isExiting = true;
                }
            }
            else
            {
                isExiting = false;
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            lbDiem_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            lbDiem_Click(sender, e);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            lbSV_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            lbSV_Click(sender, e);
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            lbGV_Click(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            lbGV_Click(sender, e);
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            lbLTC_Click(sender, e);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            lbLTC_Click(sender, e);
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            lbMH_Click(sender, e);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            lbMH_Click(sender, e);
        }

        private void DXtoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
