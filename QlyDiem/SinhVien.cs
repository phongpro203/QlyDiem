using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlyDiem
{
    internal class SinhVien
    {
        private string maSV;
        private string tenSV;
        private string queQuan;
        private string tenLop;
        private string maLop;
        private string ngaySinh;
        private string gioiTinh;
        public SinhVien()
        {

        }

        public SinhVien(string maSV, string tenSV, string queQuan, string tenLop, string maLop, string ngaySinh, string gioiTinh)
        {
            this.maSV = maSV;
            this.tenSV = tenSV;
            this.queQuan = queQuan;
            this.tenLop = tenLop;
            this.maLop = maLop;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
        }

        public string MaSV { get => maSV; set => maSV = value; }
        public string TenSV { get => tenSV; set => tenSV = value; }
        public string QueQuan { get => queQuan; set => queQuan = value; }
        public string TenLop { get => tenLop; set => tenLop = value; }
        public string MaLop { get => maLop; set => maLop = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}
