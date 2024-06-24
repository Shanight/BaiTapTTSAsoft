using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsCoBan
{
    public partial class Xem : Form
    {
        string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=test1asoft;User id=sa;password=123456";
        public string UserID { get; set; }

        public Xem()
        {
            InitializeComponent();
        }
        private void xem_load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                // Correct SQL query with parameter placeholder
                SqlCommand cmd = new SqlCommand("select * from Users where UserID = @UserID", con);
                cmd.Parameters.AddWithValue("@UserID", UserID); // Add parameter value

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt); // Fill the DataTable with data
                con.Close();
            }

            // Access data from the DataTable
            if (dt.Rows.Count > 0)
            {
                iduser.Text = dt.Rows[0]["UserID"].ToString();
                username.Text = dt.Rows[0]["UserName"].ToString();
                email.Text = dt.Rows[0]["Email"].ToString();
                phonenumber.Text = dt.Rows[0]["Tel"].ToString();
                password.Text = dt.Rows[0]["Password"].ToString();
                disabled.Checked = dt.Rows[0]["Disabled"].ToString() == "1" ? true : false;
                /* Assuming "Disabled" is a boolean column
                bool disabledValue = (bool)dt.Rows[0]["Disabled"];
                check.Checked = disabledValue; // Set the checkbox state
                */
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng với ID này.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
