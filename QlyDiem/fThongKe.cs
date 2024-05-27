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
using Excel = Microsoft.Office.Interop.Excel;

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
        public async Task LoadDataAsync()
        {
            await Task.Run(() =>
            {
                // Thực hiện các tác vụ tải dữ liệu nặng tại đây
                System.Threading.Thread.Sleep(2000); // Giả lập tải dữ liệu
            });
        }
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
                    MessageBox.Show("Vui lòng nhập mã sinh viên", "Thông báo");
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
                        MessageBox.Show("Không tìm thấy mã sinh viên trong cơ sở dữ liệu", "Thông báo");
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
                            MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo");
                        }

                        if (soTC != DBNull.Value)
                        {
                            int soTinChi = Convert.ToInt32(soTC);
                            lbSoTC.Text = soTinChi.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo");
                        }
                        sqlCommand.Dispose();
                    }
                }
            }
        }

        public void ExportFile(DataTable dt, string sheetName, string title, string msv, SqlConnection con)
        {
            // Tạo ứng dụng Excel mới
            Excel.Application oExcel = new Excel.Application();
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;

            // Tạo một Workbook mới và lấy reference tới Sheet đầu tiên
            Excel.Workbook oBook = oExcel.Workbooks.Add(Type.Missing);
            Excel.Worksheet oSheet = (Excel.Worksheet)oBook.Sheets[1];
            oSheet.Name = sheetName;

            // Tạo tiêu đề cho trang tính
            Excel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Arial";
            head.Font.Size = 20;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Tạo tên các cột
            string[] columnNames = { "MSV", "Tên sinh viên", "Mã môn", "Tên môn", "Học kỳ", "Điểm thường xuyên", "Điểm thi", "Điểm TB" };
            for (int i = 0; i < columnNames.Length; i++)
            {
                Excel.Range cell = oSheet.Cells[3, i + 1];
                cell.Value2 = columnNames[i];
                cell.Font.Bold = true;
                cell.ColumnWidth = 15; // Đặt độ rộng mặc định cho các cột

                // Đặt độ rộng riêng cho cột "Tên môn"
                if (columnNames[i] == "Tên môn")
                {
                    cell.ColumnWidth = 25;
                }

                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                cell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }

            // Điền dữ liệu từ DataTable vào Excel
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Excel.Range cell = oSheet.Cells[i + 4, j + 1];
                    cell.Value2 = dt.Rows[i][j];
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    cell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
            }

            // Tính điểm trung bình cộng của cột "Điểm TB"
            double diemtb = 0;
            if (dt.Rows.Count > 0)
            {
                diemtb = dt.AsEnumerable().Average(row => row.Field<double>("DiemTB"));
            }

            // Lấy tổng số tín chỉ từ câu lệnh SQL
            string sql = "select sum(SoTinChi) from BangDiem, MonHoc where MaSV = @MaSV and BangDiem.MaMon = MonHoc.MaMon";
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.AddWithValue("@MaSV", msv);
            object soTCObj = sqlCommand.ExecuteScalar();
            double soTC = (soTCObj != DBNull.Value) ? Convert.ToDouble(soTCObj) : 0;

            // Xác định học lực
            string hocLuc;
            if (diemtb >= 9.0)
            {
                hocLuc = "Xuất sắc";
            }
            else if (diemtb >= 8.0)
            {
                hocLuc = "Giỏi";
            }
            else if (diemtb >= 7.0)
            {
                hocLuc = "Khá";
            }
            else if (diemtb >= 5.0)
            {
                hocLuc = "Trung Bình";
            }
            else if (diemtb >= 4.0)
            {
                hocLuc = "Yếu";
            }
            else
            {
                hocLuc = "Kém";
            }

            // Thêm ba dòng chữ vào dưới bảng
            int rowStartIndex = dt.Rows.Count + 5;
            Excel.Range diemTBRange = oSheet.Cells[rowStartIndex, 1];
            diemTBRange.Value2 = $"Điểm trung bình: {diemtb:N2}";
            diemTBRange.Font.Bold = true;
            diemTBRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            Excel.Range soTCRange = oSheet.Cells[rowStartIndex + 1, 1];
            soTCRange.Value2 = $"Tổng số tín chỉ: {soTC}";
            soTCRange.Font.Bold = true;
            soTCRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            Excel.Range hocLucRange = oSheet.Cells[rowStartIndex + 2, 1];
            hocLucRange.Value2 = $"Học lực: {hocLuc}";
            hocLucRange.Font.Bold = true;
            hocLucRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Lưu tệp Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                FileName = "DataExport.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                oBook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Dữ liệu đã được xuất thành công vào tập tin Excel.", "Thông báo");
            }

            // Đóng Workbook và ứng dụng Excel
            //oBook.Close();
            //oExcel.Quit();

            // Giải phóng tài nguyên
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
            oBook = null;
            oExcel = null;
            GC.Collect();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string msv = tbTimKiemTheoMa.Text;
            string sql = "SELECT \r\n    SinhVien.MaSV, \r\n    SinhVien.TenSV,\r\n    MonHoc.MaMon,\r\n    MonHoc.TenMon,\r\n    BangDiem.HocKy,\r\n    BangDiem.DiemThuongXuyen,\r\n    BangDiem.DiemThi,\r\n    ROUND((BangDiem.DiemThi*0.6 + BangDiem.DiemThuongXuyen*0.4), 2) AS DiemTB\r\nFROM \r\n    SinhVien\r\nJOIN \r\n    BangDiem ON SinhVien.MaSV = BangDiem.MaSV\r\nJOIN \r\n    MonHoc ON BangDiem.MaMon = MonHoc.MaMon\r\nWHERE \r\n    BangDiem.MaSV = @MaSV\r\nGROUP BY \r\n    SinhVien.MaSV, \r\n    SinhVien.TenSV,\r\n    MonHoc.MaMon,\r\n    MonHoc.TenMon,\r\n    BangDiem.HocKy,\r\n    BangDiem.DiemThuongXuyen,\r\n    BangDiem.DiemThi";
            con = Connection.getSqlConnection();
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(sql, con))
            {
                sqlCommand.Parameters.AddWithValue("@MaSV", msv);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt); // Điền dữ liệu vào DataTable
                    
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Bạn cần nhập dữ liệu sinh viên cần xuất trước!", "Thông báo");
                        return;
                    }
                    dgvThongKe.DataSource = dt;
                    // Gọi hàm ExportFile để xuất dữ liệu ra Excel
                    ExportFile(dt, "Sheet1", "Báo cáo điểm sinh viên",msv,con);
                    con.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnXuatExcel_Click(sender, e);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            btnXuatExcel_Click(sender, e);
        }

        private void fThongKe_Activated_1(object sender, EventArgs e)
        {
            fThongKe_Load(sender, e);
        }
    }
}
