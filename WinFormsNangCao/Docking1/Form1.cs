using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;

namespace Docking1
{
    public partial class Form1 : Form
    {
        public object DataSource { get; set; }


        string conString = @"Data Source=.\SQLEXPRESS;Initial Catalog=test1asoft;User id=sa;password=123456";

        public Form1()
        {
            
            InitializeComponent();
            _loadData();
        }
        private void loadform(object sender, EventArgs e)
        {
            
        }
        
        public void _loadData() // tải lại trang
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY UserID) AS [STT], UserID AS [Mã nhân viên], UserName AS [Tên nhân viên], Email, Tel AS [Số điện thoại], Disabled FROM users", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable("users");
                        da.Fill(dt);
                        grdGird1.DataSource = dt;

                        int disabledColumn = grdGird1.Cols.IndexOf("Disabled"); //Tìm cột Disabled

                        grdGird1.Cols[disabledColumn].DataType = typeof(bool); //Đặt lại kiểu định dạng
                        


                        for (int i = 0; i < grdGird1.Rows.Count; i++)// Kiểm tra từng dòng
                        {
                            if (grdGird1[i, disabledColumn].ToString() == "1")
                            {
                                grdGird1[i, disabledColumn] = true; // nếu giá trị là 1 thì check
                            }
                            else
                            {
                                grdGird1.Cols[disabledColumn].Caption = "Disabled";
                                grdGird1[i, disabledColumn] = false; // nếu giá trị là 0 thì không check
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void clickfocus(object sender, MouseEventArgs e) //chuột phải hiển thị menu
        {
            if (e.Button == MouseButtons.Right)
            {
                Point mousePosition = new Point(e.X, e.Y);
                cmnuMenu1.ShowContextMenu(this, mousePosition);
            }
        }

        private void button3_Click(object sender, EventArgs e) //nhấn nút hiển thị menu tại nút thực hiện
        {
            cmnuMenu1.ShowContextMenu(btnDong, new Point(0, btnDong.Height));
        }


        private void c1Command10_Click(object sender, C1.Win.C1Command.ClickEventArgs e)// mở form "create" và đặt dữ liệu là add
        {
            Form2 Create = new Form2(this, "add","");
            Create.ShowDialog();
        }


        private void c1Command8_Click(object sender, C1.Win.C1Command.ClickEventArgs e)// mở form "create" và đặt dữ liệu là update, đồng thời truyền giá trị IDUser dòng được chọn 
        {
            C1.Win.C1FlexGrid.CellRange cr;
            cr = grdGird1.Selection;
            string userID = grdGird1[cr.r1, 2].ToString();
            Form2 Create = new Form2(this, "update", userID);
            Create.ShowDialog();
        }


        
        private void treView_Click(object sender, C1.Win.C1Command.ClickEventArgs e) // mở form "create" và đặt dữ liệu là view, đồng thời truyền giá trị IDUser dòng được chọn
        {
            C1.Win.C1FlexGrid.CellRange cr;
            cr = grdGird1.Selection;
            string userID = grdGird1[cr.r1, 2].ToString();
            Form2 Create = new Form2(this, "view", userID);
            Create.ShowDialog();
        }

        
        private void c1Command6_Click(object sender, C1.Win.C1Command.ClickEventArgs e) //thực hiện chức năng xóa
        {
            C1.Win.C1FlexGrid.CellRange cr;
            cr = grdGird1.Selection; //lấy vị trí được chọn

            if (cr.r1 > 0) // kiểm tra đã có dòng nào được chọn chưa
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    string userId = grdGird1[cr.r1, 2].ToString();// lấy IDUser ở cột thứ 2 tại dòng được chọn

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        string query = "Delete Users Where UserID=@UserID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        conn.Open();
                        var rowAffected = cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Xóa thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    grdGird1.RemoveItem(cr.r1);
                    _loadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!");
            }
        }
    }
}
