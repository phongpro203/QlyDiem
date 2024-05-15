using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlyDiem
{
    internal class GiangVien
    {
        private string maGV;
        private string tenGV;
        private string maKhoa;
        private string ngaySinh;
        private string queQuan;
        private string gioiTinh;
        private string trinhDo;
        public GiangVien() { }

        public GiangVien(string maGV, string tenGV, string maKhoa, string ngaySinh, string queQuan, string gioiTinh, string trinhDo)
        {
            this.maGV = maGV;
            this.tenGV = tenGV;
            this.maKhoa = maKhoa;
            this.ngaySinh = ngaySinh;
            this.queQuan = queQuan;
            this.gioiTinh = gioiTinh;
            this.trinhDo = trinhDo;
        }

        public string MaGV { get => maGV; set => maGV = value; }
        public string TenGV { get => tenGV; set => tenGV = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string QueQuan { get => queQuan; set => queQuan = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string TrinhDo { get => trinhDo; set => trinhDo = value; }
    }
}
