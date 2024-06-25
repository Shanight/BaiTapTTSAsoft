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


        string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=test1asoft;User id=sa;password=123456";

        public Form1()
        {
            
            InitializeComponent();
            loaddata();
        }
        private void loadform(object sender, EventArgs e)
        {
            
        }
        //loaddata
        public void loaddata()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY UserID) AS [STT], UserID AS [Mã nhân viên], UserName AS [Tên nhân viên], Email, Tel AS [Số điện thoại], Disabled FROM users", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable("users");
                        da.Fill(dt);
                        c1FlexGrid1.DataSource = dt;

                        // Find the "Disabled" column
                        int disabledColumn = c1FlexGrid1.Cols.IndexOf("Disabled");

                        // Set the column type to CheckBox
                        c1FlexGrid1.Cols[disabledColumn].DataType = typeof(bool);

                        // Set the check state based on the value
                        for (int i = 0; i < c1FlexGrid1.Rows.Count; i++)
                        {
                            if (c1FlexGrid1[i, disabledColumn].ToString() == "1")
                            {
                                c1FlexGrid1[i, disabledColumn] = true; // Checked
                            }
                            else
                            {
                                c1FlexGrid1[i, disabledColumn] = false; // Unchecked
                            }
                        }
                    }
                }
            }
        }
        //endloaddata

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //chuột phải
        private void clickfocus(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                c1ContextMenu1.ShowContextMenu(button2, new Point(0, button2.Height));
            }
        }
        //end chuột phải

        //nút thực hiện
        private void button3_Click(object sender, EventArgs e)
        {
            c1ContextMenu1.ShowContextMenu(button2, new Point(0, button2.Height));
        }
        //end thực hiện
        
        private void c1Command2_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            MessageBox.Show("thêm");
            create Create = new create(this);
            Create.ShowDialog();
        }

        private void c1Command3_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            MessageBox.Show("sửa");
        }

        private void c1Command4_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            MessageBox.Show("xem");
        }

        //nút xóa, chưa xong
        private void c1Command5_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            C1.Win.C1FlexGrid.CellRange cr;
            cr = c1FlexGrid1.Selection;

            if (cr.r1 > 0) // Check if any row is selected
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    // Get the UserID from the selected row
                    string userId = c1FlexGrid1[cr.r1, c1FlexGrid1.Cols.IndexOf("UserID")].ToString();

                    using (SqlConnection conn = new SqlConnection(constring))
                    {
                        string query = "Delete Users Where UserID=@UserID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        conn.Open();
                        var rowAffected = cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Deleted user successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    c1FlexGrid1.RemoveItem(cr.r1);
                    MessageBox.Show("Thành công");
                    loaddata();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!");
            }
        }
        //end xóa


    }
}
