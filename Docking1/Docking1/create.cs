using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Docking1
{
    public partial class create : Form
    {
        string checkid = "0";
        private Form1 reload;
        public create(Form1 reload)
        {
            InitializeComponent();
            this.reload = reload;
            button3.Visible = false;
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
                    reload.loaddata();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manv.Text = "";
            tennv.Text = "";
            matkhau.Text = "";
            nhaplaimk.Text = "";
            email.Text = "";
            tel.Text = "";
            khonghienthi.Checked = false;
            button2.Visible = true;
            button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string IDUSER = manv.Text;
            string USERNAME = tennv.Text;
            string PASSWORD = matkhau.Text;
            string PASSWORD1 = nhaplaimk.Text;
            string PHONENUMBER = tel.Text;
            string EMAIL = email.Text;
            string DISABLED = khonghienthi.Checked ? "1" : "0";

            if (IDUSER != "")
            {
                if (USERNAME != "")
                {
                    if (PASSWORD != "")
                    {
                        if (EMAIL != "" && PHONENUMBER != "" && PASSWORD1 != "")
                        {
                            if (IDUSER.Trim() == "" || IDUSER.Contains(" "))
                            {
                                MessageBox.Show("ID người dùng không được chứa khoảng trắng.");
                                manv.Focus();
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
                                        matkhau.Focus();
                                    }
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên nhân viên");
                    tennv.Focus();
                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                manv.Focus();
            }
        }
    }
}
