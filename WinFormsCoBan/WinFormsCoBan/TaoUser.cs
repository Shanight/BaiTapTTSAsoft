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
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsCoBan
{
    public partial class TaoUser : Form
    {
        string checkid = "0";
        public TaoUser()
        {
            InitializeComponent();
        }
        private void TaoUser_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iduser.Text = "";
            username.Text = "";
            password.Text = "";
            password1.Text = "";
            phonenumber.Text = "";
            email.Text = "";
            disabled.Checked = false;
            button2.Visible = true;
            button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string IDUSER = iduser.Text;
            string USERNAME = username.Text;
            string PASSWORD = password.Text;
            string PASSWORD1 = password1.Text;
            string PHONENUMBER = phonenumber.Text;
            string EMAIL = email.Text;
            string DISABLED = disabled.Checked ? "1":"0" ;

            if (IDUSER != "" && USERNAME != "" && PASSWORD != "" && EMAIL != "" && PHONENUMBER != "" && PASSWORD1 != "")
            {
                if (IDUSER.Trim() == "" || IDUSER.Contains(" "))
                {
                    MessageBox.Show("ID người dùng không được chứa khoảng trắng.");
                    iduser.Focus();
                }
                else
                {
                    if (!IsValidEmail(EMAIL))
                    {
                        MessageBox.Show("Email không hợp lệ.");
                        email.Focus();
                    }
                    else
                    {
                        if (PASSWORD == PASSWORD1)
                        {
                            checkUser(IDUSER);
                            if (checkid == "1")
                            {
                                createUser(IDUSER, USERNAME, PASSWORD, EMAIL, PHONENUMBER, DISABLED);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không khớp, vui lòng nhập lại");
                            password.Focus();
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

       
// Function to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void createUser(string UserID, string UserName, string Password, string Email, string Tel, string Disabled)
        {
            string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=test1asoft;User id=sa;password=123456";
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("Insert into Users (UserID,UserName, Password, Email,Tel,Disabled) values(@UserID,@UserName, @Password, @Email,@Tel,@Disabled)", con);
                cmd.Parameters.AddWithValue("@UserID", UserID.ToUpper());
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
                    button3.Visible = true;
                    button2.Visible = false;
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }

            }
        }

        private void checkUser(string UserID)
        {
            string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=test1asoft;User id=sa;password=123456";
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("select COUNT(*) from Users where UserID= @UserID", con);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                con.Open();
                int rowsAffected = (int)cmd.ExecuteScalar();
                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đã có người dùng ID này, vui lòng thử lại");
                    checkid = "0";
                }
                else
                {
                    checkid = "1";
                }

            }
        }
    }
}
