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
    public partial class Form2 : Form
    {
        string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=test1asoft;User id=sa;password=123456"; //đường dẫn cơ sở dữ liệu
        private string type; //đặt giá trị của type
        private string userId;//đặt giá trị của userID
        string checkID = "0";//đặt giá trị checkID
        private Form1 reload;// gọi phương thức để lấy biến từ Form1
        public Form2(Form1 reload, string type, string userID) //lấy giá trị được đưa qua và gắn vào giá trị đã tạo sẵn ở trên
        {
            InitializeComponent();
            this.reload = reload;
            btnNhapTiep.Visible = false;
            this.type = type;
            this.userId = userID;

            if (type.Equals("update") || type.Equals("view")) //nếu type được đưa qua là update và view thì sẽ hiển thị thông tin User vào bảng, nếu là view thì ngoài hiển thị, nó còn không cho phép nhấn vào và thay đổi dữ liệu
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    SqlCommand cmd = new SqlCommand("Select UserID,UserName,Password,Email,Tel,Disabled From Users Where UserID=@UserID", con);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    DataRow row = dt.Rows[0];

                    txtMaNV.Text = row["UserID"].ToString();
                    txtTenNV.Text = row["UserName"].ToString();
                    txtMatKhau.Text = row["Password"].ToString();
                    txtNhapLaiMK.Text = txtMatKhau.Text;
                    txtEmail.Text = row["Email"].ToString();
                    txtTel.Text = row["Tel"].ToString();
                    chkKhongHienThi.Checked = Convert.ToBoolean(row["Disabled"]);

                    txtMaNV.Enabled = false;
                    if (type.Equals("view"))
                    {
                        txtTenNV.Enabled = false;
                        txtMatKhau.Enabled = false;
                        txtNhapLaiMK.Enabled = false;
                        txtEmail.Enabled = false;
                        txtTel.Enabled = false;
                        chkKhongHienThi.Enabled = false;
                        txtMatKhau.Multiline = true;
                        txtNhapLaiMK.Multiline = true;
                        btnGui.Visible = false;
                        btnNhapTiep.Visible = false;
                    }
                }
            }
        }
        private void checkUser(string UserID) //Kiểm tra UserID coi đã có trên database chưa
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
                    checkID = "0";//nếu có thì sẽ báo lỗi và cho checkID = 0
                }
                else
                {
                    checkID = "1";//nếu chưa có thì sẽ cho checkID = 1
                }
            }
        }

        private void createUser(string UserID, string UserName, string Password, string Email, string Tel, string Disabled)
        {
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
                    reload._loadData();
                    btnNhapTiep.Visible = true;
                    btnGui.Visible = false;
                    MessageBox.Show("Thêm thành công");

                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }

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
                    reload._loadData();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
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
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtMatKhau.Text = "";
            txtNhapLaiMK.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
            chkKhongHienThi.Checked = false;
            btnGui.Visible = true;
            btnNhapTiep.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idUser = txtMaNV.Text;
            string userName = txtTenNV.Text;
            string passWord = txtMatKhau.Text;
            string nhaplaiMK = txtNhapLaiMK.Text;
            string phoneNumber = txtTel.Text;
            string email = txtEmail.Text;
            string disabled = chkKhongHienThi.Checked ? "1" : "0";

            if (idUser.Trim() == "" || idUser.Contains(" "))
            {
                MessageBox.Show("Mã nhân viên không được chứa khoảng trắng.");
                txtMaNV.Focus();
            }
            else
            if (userName == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên.");
                txtTenNV.Focus();
            }
            else if(userName == "" || passWord == "" || email == "" || phoneNumber == "" || nhaplaiMK == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.");
                txtEmail.Focus();
            }
            else if (passWord != nhaplaiMK)
            {
                MessageBox.Show("Mật khẩu không khớp, vui lòng nhập lại");
                txtMatKhau.Focus();
            }
            else
            {
                if (type.Equals("update"))
                {
                    updateUser(idUser, userName, passWord, email, phoneNumber, disabled);
                }
                else
                {
                    checkUser(idUser);
                    if (checkID == "1")
                    {
                        createUser(idUser, userName, passWord, email, phoneNumber, disabled);
                    }
                }
            }
        }
    }
}
