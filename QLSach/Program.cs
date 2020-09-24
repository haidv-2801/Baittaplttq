using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach
{
    class Program
    {

        static void Main(string[] args)
        {
            List<SachMoi> listSach = new List<SachMoi>();

            int i = 0;

            do
            {

                Console.WriteLine("Nhap sach thu {0} :", ++i);
                SachMoi a = new SachMoi();
                a.nhap();
                listSach.Add(a);
                Console.Write("Nhap them(N-khong, Y-co):");
            } while (Console.ReadLine().ToLower() == "y");


            int kt = 0;
            Console.Write("Nhap QR code muon tim:");
            string QRSearch = Console.ReadLine();
            foreach (SachMoi s in listSach)
            {
                //if (s.Qrcode.Contains(QRSearch) == true)
                if (QRSearch.CompareTo(s.Qrcode) == 0)
                {
                    kt = 1;
                    //s.xuat();
                    Console.WriteLine(s.ToString());
                }
            }

            if (kt == 0)
            {
                Console.WriteLine("Khong tim thay " + QRSearch.ToString());
            }
            //
            Console.ReadKey();
        }
    }
}
