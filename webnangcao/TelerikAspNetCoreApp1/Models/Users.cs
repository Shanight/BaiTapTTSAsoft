using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace TelerikAspNetCoreApp1.Models
{
    public class Users
    {
        private static string connectionString = @"Server=.\SQLEXPRESS;Database=test1asoft;User Id=sa;Password=123456;Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=True";

        public IList<UserViewModel> GetAll()
        {
            IList<UserViewModel> result = new List<UserViewModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT UserID, UserName, Password, Email, Tel, Disabled FROM Users";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new UserViewModel
                            {
                                UserID = reader.GetString(reader.GetOrdinal("UserID")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Tel = reader.GetString(reader.GetOrdinal("Tel")),
                                Disabled = reader.GetInt32(reader.GetOrdinal("Disabled"))
                            };
                            result.Add(user);
                        }
                    }
                }
            }

            return result;
        }

        public void Dispose()
        {

        }
        /*
        private string strConString = @"Server=.\SQLEXPRESS;Database=test1asoft;User Id=sa;Password=123456;Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=True";
        public bool CheckExistingUser(string userID)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string checkSql = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID";
                SqlCommand checkCmd = new SqlCommand(checkSql, con);
                checkCmd.Parameters.AddWithValue("@UserID", userID);
                int existingUserCount = (int)checkCmd.ExecuteScalar();

                return existingUserCount > 0;
            }
        }
        public DataTable GetUserByID(string UserID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {

                con.Open();
                string query = "Select * from users where UserID=@UserID";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Select * from Users", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;


        }
        public string InsertUsers(string UserID, string UserName, string Password, string Email, string Tel, string Disabled)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string checkSql = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID";
                SqlCommand checkCmd = new SqlCommand(checkSql, con);
                checkCmd.Parameters.AddWithValue("@UserID", UserID);
                int existingUserCount = (int)checkCmd.ExecuteScalar();


                string sql = "Insert into Users (UserID,UserName, Password, Email,Tel,Disabled) values(@UserID,@UserName, @Password, @Email,@Tel,@Disabled)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Tel", Tel);
                cmd.Parameters.AddWithValue("@Disabled", Disabled);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return "Dữ liệu đã được chèn thành công.";
                }
                else
                {
                    return "Đã xảy ra lỗi khi chèn dữ liệu.";
                }
            }
        }

        public int UpdateUser(string UserID, string UserName, string Password, string Email, string Tel, string Disabled)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Update Users SET UserID=@UserID, UserName=@UserName, Password=@Password, Email=@Email, Tel=@Tel, Disabled=@Disabled where UserID=@UserID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", UserID.ToUpper());
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Tel", Tel);
                cmd.Parameters.AddWithValue("@Disabled", Disabled);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteUser(string UserID)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Delete from users where UserID=@UserID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                return cmd.ExecuteNonQuery();
            }
        }
        */

        [Display(Name = "Id")]
        [Required(ErrorMessage = "Bắt buộc nhập UserID")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int Disabled { get; set; }

        
    }
}
