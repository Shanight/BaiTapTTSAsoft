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
using System.Reflection;


namespace WinFormsCoBan
{
    public partial class UpdateUser : Form
    {
        string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=test1asoft;User id=sa;password=123456";
        public string UserID { get; set; }
        
        public UpdateUser()
        {
            InitializeComponent();
        }
        private void update_load(object sender, EventArgs e)
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
                password1.Text = dt.Rows[0]["Password"].ToString();
                disabled.Checked = dt.Rows[0]["Disabled"].ToString() == "1" ? true : false  ;
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

        private void button2_Click(object sender, EventArgs e)
        {
            string IDUSER = iduser.Text;
            string USERNAME = username.Text;
            string PASSWORD = password.Text;
            string PASSWORD1 = password1.Text;
            string PHONENUMBER = phonenumber.Text;
            string EMAIL = email.Text;
            string DISABLED = disabled.Checked ? "1" : "0";

            if (IDUSER != "" && USERNAME != "" && PASSWORD != "" && EMAIL != "" && PHONENUMBER != "" && PASSWORD1 != "")
            {
                if (PASSWORD == PASSWORD1)
                {
                    updateUser(IDUSER, USERNAME, PASSWORD, EMAIL, PHONENUMBER, DISABLED);
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp, vui lòng nhập lại");
                    password.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        private void updateUser(string UserID, string UserName, string Password, string Email, string Tel, string Disabled)
        {
            string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=test1asoft;User id=sa;password=123456";
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("Update Users SET UserID=@UserID, UserName=@UserName, Password=@Password, Email=@Email, Tel=@Tel, Disabled=@Disabled where UserID=@UserID", con);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Tel", Tel);
                cmd.Parameters.AddWithValue("@Disabled", Disabled);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }

            }
        }
    }
}
