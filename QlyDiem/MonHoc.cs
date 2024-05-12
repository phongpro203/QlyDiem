using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlyDiem
{
    internal class MonHoc
    {
        private string maMon;
        private string tenMon;
        private int soTinChi;

        public MonHoc()
        {
        }

        public MonHoc(string maMon, string tenMon, int soTinChi)
        {
            this.MaMon = maMon;
            this.TenMon = tenMon;
            this.SoTinChi = soTinChi;
        }

        public string MaMon { get => maMon; set => maMon = value; }
        public string TenMon { get => tenMon; set => tenMon = value; }
        public int SoTinChi { get => soTinChi; set => soTinChi = value; }
    }
}
