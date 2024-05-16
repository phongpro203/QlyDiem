using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlyDiem
{
    internal class Lop
    {
        string maLop;
        string tenLop;
        string khoa;
        public Lop()
        {

        }
        public Lop(string maLop, string tenLop, string khoa)
        {
            this.MaLop = maLop;
            this.TenLop = tenLop;
            this.Khoa = khoa;
        }

        public string MaLop { get => maLop; set => maLop = value; }
        public string TenLop { get => tenLop; set => tenLop = value; }
        public string Khoa { get => khoa; set => khoa = value; }
    }
}
