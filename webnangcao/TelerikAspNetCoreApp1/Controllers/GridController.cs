using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Telerik.SvgIcons;
using TelerikAspNetCoreApp1.Models;

namespace TelerikAspNetCoreApp1.Controllers
{
    public class GridController : Controller
    {
        private string strConString = @"Server=.\SQLEXPRESS;Database=test1asoft;User Id=sa;Password=123456;Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=True";

        
/*
        public ActionResult Orders_Read([DataSourceRequest] DataSourceRequest request)
        {
            
            var result = Enumerable.Range(0, 50).Select(i => new OrderViewModel
            {
                OrderID = i,
                Freight = i * 10,
                OrderDate = new DateTime(2016, 9, 15).AddDays(i % 7),
                ShipName = "ShipName " + i,
                ShipCity = "ShipCity " + i
            });

            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
            
        }*/

        public ActionResult DocUser([DataSourceRequest] DataSourceRequest request)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                return Json(dt.ToDataSourceResult(request));
            } 
        }

        public ActionResult CreateUser([DataSourceRequest] DataSourceRequest request, string UserID, string UserName, string Password, string Email, string Tel, string Disabled)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();

                string checkSql = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID";
                SqlCommand checkCmd = new SqlCommand(checkSql, con);
                checkCmd.Parameters.AddWithValue("@UserID", UserID);
                int existingUserCount = (int)checkCmd.ExecuteScalar();
                if (existingUserCount > 0)
                {
                    // Nếu UserID đã tồn tại, trả về lỗi
                    return Json(new { errors = new { UserID = new string[] { "UserID đã tồn tại." } } });
                }

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
                    return Json(new { success = "Dữ liệu đã được chèn thành công." });
                }
                else
                {
                    return Json(new { errors = "Đã xảy ra lỗi khi chèn dữ liệu." });
                }
            }
        }

        public ActionResult UpdateUser([DataSourceRequest] DataSourceRequest request, string UserID, string UserName, string Password, string Email, string Tel, string Disabled)
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
                cmd.Parameters.AddWithValue("@Disabled", Disabled );
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Json(new { success = "Dữ liệu đã được chèn thành công." });
                }
                else
                {
                    return Json(new { errors = "Đã xảy ra lỗi khi chèn dữ liệu." });
                }
            }
        }
        public ActionResult CheckID(string UserID)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();

                string checkSql = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID";
                SqlCommand checkCmd = new SqlCommand(checkSql, con);
                checkCmd.Parameters.AddWithValue("@UserID", UserID);
                int existingUserCount = (int)checkCmd.ExecuteScalar();
                if (existingUserCount > 0)
                {
                    // UserID đã tồn tại, tạo một ModelStateError và trả về dưới dạng JSON
                    ModelState.AddModelError("UserID", "UserID đã tồn tại.");
                    var errors = ModelState.ToDataSourceResult();
                    return Json(new { errors });
                }

                // UserID không tồn tại, trả về một JSON trống để chỉ định rằng không có lỗi xảy ra
                return Json(new { });
            }
        }


        public ActionResult DeleteUser([DataSourceRequest] DataSourceRequest request,string UserID)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Delete from users where UserID=@UserID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                return Json(cmd.ExecuteNonQuery());
            }
        }

        internal int UpdateUser(string userID, string userName, string password, string email, string tel, string disabled)
        {
            throw new NotImplementedException();
        }
    }
}
