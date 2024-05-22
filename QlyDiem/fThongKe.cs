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
    public partial class fThongKe : Form
    {
        public fThongKe()
        {
            InitializeComponent();
        }
        SqlCommand sqlCommand = null;
        SqlConnection con = null;
        SqlDataAdapter da = null;
        private void tbTimKiemTheoMa_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoMa.Clear();
        }

        private void fThongKe_Load(object sender, EventArgs e)
        {
            using (con = Connection.getSqlConnection())
            {
                DataTable dt = new DataTable();
                con.Open();
                string sql = "SELECT \r\n    sv.MaSV, " +
                    "\r\n    sv.TenSV, \r\n    round(AVG(bd.DiemThi*0.6 +bd.DiemThuongXuyen*0.4),2) AS 'Diem TB',  \r\n " +
                    "   Sum(mh.SoTinChi) AS 'Tong tin chi'\r\nFROM \r\n    SinhVien sv\r\nJOIN \r\n   " +
                    " BangDiem bd ON sv.MaSV = bd.MaSV\r\nJOIN \r\n    " +
                    "MonHoc mh ON bd.MaMon = mh.MaMon\r\nGROUP BY \r\n    sv.MaSV, sv.TenSV;";
                da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                try
                {

                    dgvThongKe.DataSource = dt;
                    dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvThongKe.Columns[0].HeaderText = "MSV";
                    dgvThongKe.Columns[1].HeaderText = "Tên sinh viên";
                    dgvThongKe.Columns[2].HeaderText = "Điểm trung bình";
                    dgvThongKe.Columns[3].HeaderText = "Tổng TC";
                    dgvThongKe.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
                }
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            tbTimKiemTheoMa.Text = "Nhập mã sinh viên";
            lbSoTC.Text = "";
            lbHocLuc.Text = "";
            lbDTB.Text = "";
            fThongKe_Load(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            const string macdinh = "Nhập mã sinh viên";
            using (con = Connection.getSqlConnection())
            {
                DataTable dt = new DataTable();
                con.Open();
                string msv = tbTimKiemTheoMa.Text;
                if(msv == macdinh || msv == "")
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên");
                    return;
                }
                //Kiem tra xem du lieu nhap vao co hay ko
                string checkSql = "SELECT COUNT(1) FROM BangDiem WHERE MaSV = @MaSV";
                using (SqlCommand checkCommand = new SqlCommand(checkSql, con))
                {
                    checkCommand.Parameters.AddWithValue("@MaSV", msv);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy mã sinh viên trong cơ sở dữ liệu");
                        return;
                    }
                }
                string sql = "SELECT \r\n    SinhVien.MaSV, \r\n    SinhVien.TenSV,\r\n    MonHoc.MaMon,\r\n    MonHoc.TenMon,\r\n    BangDiem.HocKy,\r\n    BangDiem.DiemThuongXuyen,\r\n    BangDiem.DiemThi,\r\n    ROUND((BangDiem.DiemThi*0.6 + BangDiem.DiemThuongXuyen*0.4), 2) AS DiemTB\r\nFROM \r\n    SinhVien\r\nJOIN \r\n    BangDiem ON SinhVien.MaSV = BangDiem.MaSV\r\nJOIN \r\n    MonHoc ON BangDiem.MaMon = MonHoc.MaMon\r\nWHERE \r\n    BangDiem.MaSV = @MaSV\r\nGROUP BY \r\n    SinhVien.MaSV, \r\n    SinhVien.TenSV,\r\n    MonHoc.MaMon,\r\n    MonHoc.TenMon,\r\n    BangDiem.HocKy,\r\n    BangDiem.DiemThuongXuyen,\r\n    BangDiem.DiemThi";
                using (sqlCommand = new SqlCommand(sql, con))
                {
                    sqlCommand.Parameters.AddWithValue("@MaSV", msv);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(dt); // Điền dữ liệu vào DataTable
                        dgvThongKe.DataSource = dt;
                        dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvThongKe.Columns[0].FillWeight = 50;
                        dgvThongKe.Columns[2].FillWeight = 60;
                        dgvThongKe.Columns[4].FillWeight = 60;
                        dgvThongKe.Columns[6].FillWeight = 70;
                        dgvThongKe.Columns[7].FillWeight = 70;
                        dgvThongKe.Columns[0].HeaderText = "MSV";
                        dgvThongKe.Columns[1].HeaderText = "Tên sinh viên";
                        dgvThongKe.Columns[2].HeaderText = "Mã môn";
                        dgvThongKe.Columns[3].HeaderText = "Tên môn";
                        dgvThongKe.Columns[4].HeaderText = "Học kỳ";
                        dgvThongKe.Columns[5].HeaderText = "Điểm thường xuyên";
                        dgvThongKe.Columns[6].HeaderText = "Điểm thi";
                        dgvThongKe.Columns[7].HeaderText = "Điểm TB";
                        dgvThongKe.ReadOnly = true;
                        sql = "select avg(DiemThi*0.6 + DiemThuongXuyen*0.4) from BangDiem where MaSV = @MaSV";
                        sqlCommand = new SqlCommand(sql, con);
                        sqlCommand.Parameters.AddWithValue("@MaSV", msv);
                        object diemTB = sqlCommand.ExecuteScalar();
                        sql = "select sum(SoTinChi) from BangDiem, MonHoc where MaSV = @MaSV and BangDiem.MaMon = MonHoc.MaMon";
                        sqlCommand = new SqlCommand(sql, con);
                        sqlCommand.Parameters.AddWithValue("@MaSV", msv);
                        object soTC = sqlCommand.ExecuteScalar();
                        if (diemTB != DBNull.Value)
                        {
                            double diemtb = Convert.ToDouble(diemTB);
                            string formattedDiemTB = diemtb.ToString("N2");
                            lbDTB.Text = formattedDiemTB;
                            if (diemtb >= 9.0)
                            {
                                lbHocLuc.Text = "Xuất xắc";
                            }
                            else if (diemtb >= 8.0)
                            {
                                lbHocLuc.Text = "Giỏi";
                            }
                            else if (diemtb >= 7.0)
                            {
                                lbHocLuc.Text = "Khá";
                            }
                            else if (diemtb >= 5.0)
                            {
                                lbHocLuc.Text = "Trung Bình";
                            }
                            else if (diemtb >= 4.0)
                            {
                                lbHocLuc.Text = "Yếu";
                            }
                            else
                            {
                                lbHocLuc.Text = "Kém";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu!");
                        }

                        if (soTC != DBNull.Value)
                        {
                            int soTinChi = Convert.ToInt32(soTC);
                            lbSoTC.Text = soTinChi.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu!");
                        }
                        sqlCommand.Dispose();
                    }
                }
            }
        }

        private void fThongKe_Activated(object sender, EventArgs e)
        {
            fThongKe_Load(sender, e);
        }
    }
}
