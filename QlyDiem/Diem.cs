using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlyDiem
{
    internal class Diem
    {
        private string maSV;
        private string maMon;
        private string hocKy;
        private float diemThi;
        private float diemTX;

        public Diem(string maSV, string maMon, string hocKy, float diemThi, float diemTX)
        {
            this.maSV = maSV;
            this.maMon = maMon;
            this.hocKy = hocKy;
            this.diemThi = diemThi;
            this.diemTX = diemTX;
        }

        public string MaSV { get => maSV; set => maSV = value; }
        public string MaMon { get => maMon; set => maMon = value; }
        public string HocKy { get => hocKy; set => hocKy = value; }
        public float DiemThi { get => diemThi; set => diemThi = value; }
        public float DiemTX { get => diemTX; set => diemTX = value; }
    }
}
