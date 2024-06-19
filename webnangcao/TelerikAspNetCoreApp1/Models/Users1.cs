using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System;

namespace TelerikAspNetCoreApp1.Models
{
    public class Users1 : IDisposable
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
        public IEnumerable<UserViewModel> Read()
        {
            return GetAll();
        }
        public void Dispose()
        {
            
        }
        
        /*
        public IEnumerable<UserViewModel> Read()
        {
            return GetAll();
        }

        public void Create(UserViewModel user)
        {
            if (!UpdateDatabase)
            {
                var first = GetAll().OrderByDescending(e => e.UserID).FirstOrDefault();
                var id = (first != null) ? first.UserID : 0;

                user.UserID = id + 1;

                if (user.CategoryID == null)
                {
                    user.CategoryID = 1;
                }

                if (user.Category == null)
                {
                    user.Category = new CategoryViewModel() { CategoryID = 1, CategoryName = "Beverages" };
                }

                GetAll().Insert(0, user);
            }
            else
            {
                var entity = new User();

                entity.UserName = user.UserName;
                entity.UnitPrice = user.UnitPrice;
                entity.UnitsInStock = (short)user.UnitsInStock;
                entity.Discontinued = user.Discontinued;
                entity.CategoryID = user.CategoryID;

                if (entity.CategoryID == null)
                {
                    entity.CategoryID = 1;
                }

                if (user.Category != null)
                {
                    entity.CategoryID = user.Category.CategoryID;
                }

                entities.Users.Add(entity);
                entities.SaveChanges();

                user.UserID = entity.UserID;
            }
        }

        public void Update(UserViewModel user)
        {
            if (!UpdateDatabase)
            {
                var target = One(e => e.UserID == user.UserID);

                if (target != null)
                {
                    target.UserName = user.UserName;
                    target.UnitPrice = user.UnitPrice;
                    target.UnitsInStock = user.UnitsInStock;
                    target.Discontinued = user.Discontinued;

                    if (user.CategoryID == null)
                    {
                        user.CategoryID = 1;
                    }

                    if (user.Category != null)
                    {
                        user.CategoryID = user.Category.CategoryID;
                    }
                    else
                    {
                        user.Category = new CategoryViewModel()
                        {
                            CategoryID = (int)user.CategoryID,
                            CategoryName = entities.Categories.Where(s => s.CategoryID == user.CategoryID).Select(s => s.CategoryName).First()
                        };
                    }

                    target.CategoryID = user.CategoryID;
                    target.Category = user.Category;
                }
            }
            else
            {
                var entity = new User();

                entity.UserID = user.UserID;
                entity.UserName = user.UserName;
                entity.UnitPrice = user.UnitPrice;
                entity.UnitsInStock = (short)user.UnitsInStock;
                entity.Discontinued = user.Discontinued;
                entity.CategoryID = user.CategoryID;

                if (user.Category != null)
                {
                    entity.CategoryID = user.Category.CategoryID;
                }

                entities.Users.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void Destroy(UserViewModel user)
        {
            if (!UpdateDatabase)
            {
                var target = GetAll().FirstOrDefault(p => p.UserID == user.UserID);
                if (target != null)
                {
                    GetAll().Remove(target);
                }
            }
            else
            {
                var entity = new User();

                entity.UserID = user.UserID;

                entities.Users.Attach(entity);

                entities.Users.Remove(entity);

                var orderDetails = entities.OrderDetails.Where(pd => pd.UserID == entity.UserID);

                foreach (var orderDetail in orderDetails)
                {
                    entities.OrderDetails.Remove(orderDetail);
                }

                entities.SaveChanges();
            }
        }
        */


    }

    public class UserViewModel
    {

        [Display(Name = "Id")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public int Disabled { get; set; }
    }
}
