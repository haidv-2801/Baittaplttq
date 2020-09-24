using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSach;
using System.Data.SqlClient;


namespace QLSachApp
{
    class SachDAO
    {
        Connect conn;
        public SachDAO()
        {
            conn = new Connect();
        }
        public  bool insert(SachMoi a)
        {
            string query = "insert into " +
                "Sach(id, sname, author, amount, qrcode) " +
                "values (@id, @name, @author, @amount, @qrcode)";
            SqlConnection con = conn.getConnect();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", a.MaSach);
                cmd.Parameters.AddWithValue("@name", a.TenSach);
                cmd.Parameters.AddWithValue("@author", a.TacGia);
                cmd.Parameters.AddWithValue("@amount", a.SoLuong.ToString());
                cmd.Parameters.AddWithValue("@qrcode", a.Qrcode);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
