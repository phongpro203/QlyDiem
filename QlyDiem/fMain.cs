using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyDiem
{
    public partial class fMain : Form
    {
        //khoi tao cac form
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
            //khoi tao cac form
            fDiem = new fDiem();
            fSinhVien = new fSinhVien();
            fGiangVien = new fGiangVien();
            fLop = new fLop();
            fMonHoc = new fMonHoc();
            fThongKe = new fThongKe();
            //tao form con
            fDiem.MdiParent = this;
            fDiem.Dock = DockStyle.Fill;
            fSinhVien.MdiParent = this;
            fSinhVien.Dock = DockStyle.Fill;
            fGiangVien.MdiParent = this;
            fGiangVien.Dock = DockStyle.Fill;
            fLop.MdiParent = this;
            fLop.Dock = DockStyle.Fill;
            fMonHoc.MdiParent = this;
            fMonHoc.Dock = DockStyle.Fill;
            fThongKe.MdiParent = this;
            fThongKe.Dock = DockStyle.Fill;
        }
        private void hideAllForm()
        {
            fDiem.Hide();
            fSinhVien.Hide();
            fGiangVien.Hide();  
            fLop.Hide();
            fMonHoc.Hide();
        }
        private void lbSV_Click(object sender, EventArgs e)
        {
            hideAllForm();
            fSinhVien.Show();
        }

        private void lbDiem_Click(object sender, EventArgs e)
        {
            hideAllForm();
            fDiem.Show();
        }

        private void lbGV_Click(object sender, EventArgs e)
        {
            hideAllForm();
            fGiangVien.Show();
        }

        private void lbLTC_Click(object sender, EventArgs e)
        {
            hideAllForm();
            fLop.Show();
        }

        private void lbMH_Click(object sender, EventArgs e)
        {
            hideAllForm();
            fMonHoc.Show();
        }
        private void ThongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllForm();
            fThongKe.Show();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllForm();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            hideAllForm();
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

    }
}
