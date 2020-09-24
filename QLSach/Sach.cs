using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach
{
    class Sach
    {
        string maSach;
        string tenSach;
        string tacGia;
        int soLuong;

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TacGia { get => tacGia; set => tacGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        

        public Sach()
        {
            this.maSach = "";
            this.tenSach = "";
            this.tacGia = "";
            this.soLuong = 0;
        }

        public Sach(string maSach, string tenSach, string tacGia, int soLuong)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.tacGia = tacGia;
            this.soLuong = soLuong;
        }

        public void nhap()
        {
            Console.Write("ma sach:"); maSach = Console.ReadLine();
            Console.Write("ten sach:"); tenSach = Console.ReadLine();
            Console.Write("ten tac gia:"); tacGia = Console.ReadLine();
            Console.Write("so luong:"); soLuong = int.Parse(Console.ReadLine()); 
        }

        public void xuat()
        {
            Console.Write(maSach+" "+tenSach+" "+tacGia+" "+soLuong); 
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
