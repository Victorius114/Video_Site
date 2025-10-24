using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Video_Site.Controllers
{
    public class AccountController : Controller
    {
        private string connectionString = "Server= DESKTOP-VICTOR1\\SQLEXPRESS; Database = Video_Site; User Id = sa; Password = 1234;";
        [HttpGet]
        public ActionResult Login() { 
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string PassWord)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DangNhap", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("username", UserName);
                cmd.Parameters.AddWithValue("password", PassWord);

                SqlDataReader dr = cmd.ExecuteReader();
            }
        }
    }
}
