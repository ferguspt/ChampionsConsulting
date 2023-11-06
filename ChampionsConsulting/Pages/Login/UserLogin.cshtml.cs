using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.Login
{
    public class UserLoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string UserType { get; set; }

        public IActionResult OnGet(String logout)
        {
            if (logout == "true")
            {
                HttpContext.Session.Clear();
                ViewData["LoginMessage"] = "Successfully Logged Out!";
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            string loginQuery = "SELECT Username, UserType FROM [User] WHERE Username = @Username AND UserPassword = @Password";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", Username),
                new SqlParameter("@Password", Password)
            };

            //For incomplete form
            if (Username == null || Password == null)
            {
                ViewData["LoginMessage"] = "Please enter all information";
                DBClass.Lab3DBConnection.Close();
                ModelState.Clear(); // used to ignore validation
                return Page();
            }

            using (SqlCommand command = new SqlCommand(loginQuery, DBClass.Lab3DBConnection))
            {
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);

                SqlDataReader reader = DBClass.LoginReader(loginQuery, parameters);

                if (reader.Read())
                {
                    HttpContext.Session.SetString("Username", reader["Username"].ToString());
                    HttpContext.Session.SetString("UserType", reader["UserType"].ToString());
                    DBClass.Lab3DBConnection.Close();
                    return RedirectToPage("/Login/UserPage");
                }
                else
                {
                    ViewData["LoginMessage"] = "Username and/or Password Incorrect";
                    DBClass.Lab3DBConnection.Close();
                    return Page();
                }
            }
        }


        public IActionResult OnPostLogoutHandler()
        {
            HttpContext.Session.Clear();
            return Page();
        }
        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("../Index");
        }
    }
}
