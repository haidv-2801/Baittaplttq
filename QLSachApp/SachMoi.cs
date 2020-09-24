using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach
{
    class SachMoi : Sach //mac dinh la public
    {
        string qrcode;
        public SachMoi() : base()
        {
            this.qrcode = "";
        }

        public SachMoi(string ma, string ts, string tg, int sl, string qrcode) : base(ma, ts, tg, sl)
        {
            this.qrcode = qrcode;
        }

        public string Qrcode { get => qrcode; set => qrcode = value; }

        public new void nhap()
        {
            base.nhap();
            Console.Write("QR code:"); qrcode = Console.ReadLine();
        }

        public new void xuat()
        {
            base.xuat();
            Console.Write(" " + qrcode);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return base.ToString() + " " + qrcode;
        }
    }
}
