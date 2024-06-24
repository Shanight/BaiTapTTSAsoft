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
    public partial class Delete : Form
    {
        private Form1 mainForm;
        string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=test1asoft;User id=sa;password=123456";
        public string UserID { get; set; }

        public Delete(Form1 form1)
        {
            InitializeComponent();
            mainForm = form1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                // Correct SQL query with parameter placeholder
                SqlCommand cmd = new SqlCommand("delete Users where UserID = @UserID", con);
                cmd.Parameters.AddWithValue("@UserID", UserID); // Add parameter value
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt); // Fill the DataTable with data
                con.Close();
            }
            MessageBox.Show("Xóa thành công");
            this.Close();
        }
    }
}
