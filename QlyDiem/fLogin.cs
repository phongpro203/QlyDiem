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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            
        }

        private void cbPass_CheckedChanged(object sender, EventArgs e)
        {
            if(cbPass.Checked)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtuser.Text = "";
            txtpass.Text = "";
            txtuser.Focus();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = Connection.getSqlConnection();
            string user = txtuser.Text;
            string pass = txtpass.Text;
            if(user == "")
            {
                MessageBox.Show("Không được để trống tài khoản!", "Thông báo");  
                txtuser.Focus();
                return;
            }
            
            if (pass == "")
            {
                MessageBox.Show("Không được để trống mật khẩu!", "Thông báo");    
                txtpass.Focus();
                return;
            }
           
            string sql = "select * from DangNhap where TenDangNhap = @TenDangNhap and MatKhau = @MatKhau;";
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@TenDangNhap", user);
                cmd.Parameters.AddWithValue("@MatKhau", pass);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    fMain fMain = new fMain();
                    this.Hide();
                    fMain.Show();                  
                }
                else 
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông báo");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra vui lòng kiểm tra lại!", "Thông báo");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void fLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnDN_Click(sender, e);
            }
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            fLogin_KeyPress (sender, e);
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            fLogin_KeyPress (sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
