using QLSach;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data.SqlClient;

namespace QLSachApp
{

    public partial class Form1 : Form
    {

        Connect myCon;
        SachDAO sda;
        public Form1()
        {
            InitializeComponent();
            myCon = new Connect();
            sda = new SachDAO();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (checkData() == false) return;

            if (alreadyExists(id.Text, "Sach", "id") == true)
            {
                MessageBox.Show("Id đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (alreadyExists(QRtext.Text, "Sach", "qrcode") == true)
            {
                MessageBox.Show("QRCode đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            SachMoi s = new SachMoi(id.Text, name.Text, author.Text,
                int.Parse(amount.Text), QRtext.Text);


            bool canConnect = sda.insert(s);
            if (canConnect == true)
            {
                MessageBox.Show("Insert successfull!");
                clear();
            }
            else
            {
                MessageBox.Show("Insert Fail!");
            }
            Form1_Load(sender, e);
        }


        private void Delete_Click(object sender, EventArgs e)
        {
            string content =
                Interaction.InputBox("Nhập mã sách:", "Xóa", "", 500, 300);

            if (string.IsNullOrWhiteSpace(content))
            {
                return;
            }

        
            {
                MessageBox.Show("Không thấy sách cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            

          
            MessageBox.Show("Xóa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            //showData(listSachMoi);

        }


        public DataTable createTable()
        {
            DataTable dtb = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["QLSachApp.Properties.Settings.Setting"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(conString))
            {
                using (SqlCommand comm = new SqlCommand("select * from Sach", myConn))
                {
                    myConn.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    dtb.Load(reader);
                }
            }
            return dtb;
        }
        private void showData()
        {
            tableData.DataSource = createTable();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        public bool checkData()
        {
            if (string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("Bạn chưa nhập id!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                id.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(name.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sách!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                name.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(author.Text))
            {
                MessageBox.Show("Bạn chưa nhập tác giả!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                author.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(amount.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                amount.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(QRtext.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã QR!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                QRtext.Focus();
                return false;
            }


            return true;
        }

        public bool isNumeric(string num)
        {
            return num.All(char.IsNumber);
        }
        private void Amount_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {
            if (!isNumeric(amount.Text))
            {
                MessageBox.Show("Số lượng phải là số!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                amount.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void clear()
        {
            id.Text = "";
            name.Text = "";
            author.Text = "";
            amount.Text = "";
            QRtext.Text = "";
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            string content =
                Interaction.InputBox("Nhập mã QR:", "Tìm kiếm", "", 500, 300);

            if (string.IsNullOrWhiteSpace(content))
            {
                //showData(listSachMoi);
                return;
            }

     
            {
                MessageBox.Show("Không thấy sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //showData(new List<SachMoi>() { dic1[content] });
        }

        private void TableData_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void TableData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                id.Text = tableData.Rows[index].Cells["id"].Value.ToString();
                name.Text = tableData.Rows[index].Cells["sname"].Value.ToString();
                author.Text = tableData.Rows[index].Cells["author"].Value.ToString();
                amount.Text = tableData.Rows[index].Cells["amount"].Value.ToString();
                QRtext.Text = tableData.Rows[index].Cells["qrcode"].Value.ToString();
            }
        }

        private bool alreadyExists(string key, string table, string param)
        {
            SqlConnection conn = myCon.getConnect();
            conn.Open();

            SqlCommand comm = new SqlCommand("select * from " + table + " where " + param + "=" + key, conn);

            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                return true;
            }
            return false;
        }
    }
}
