using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.Login
{
    public class CreateUserModel : PageModel
    {
        [BindProperty]
        [Required]
        public String FirstName { get; set; }

        [BindProperty]
        [Required]
        public String LastName { get; set; }

        [BindProperty]
        [Required]
        public String Username { get; set; }

        [BindProperty]
        [Required]
        public String Password { get; set; }

        [BindProperty]
        [Required]
        public String Email { get; set; }

        [BindProperty]
        [Required]
        public String UserType { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string selectQuery = $"SELECT * FROM Users WHERE Username = '{Username}'";
            SqlDataReader UserReader = DBClass.UserReader(selectQuery);

            if (UserReader.HasRows)
            {
                ModelState.AddModelError("Username", "Username already exists.");
                TempData["FailMessage"] = "Username already exists.";
                DBClass.CCDBConnection.Close();
                ModelState.Clear(); // used to ignore validation
                return Page();
            }

            if (Username != null && Password != null && FirstName != null && LastName != null && Email != null)
            {
                // Hash the password before storing it in the database
                string hashedPassword = PasswordHash.HashPassword(Password);
                DBClass.CreateHashedUser(Username, hashedPassword); // Store hashedPassword instead of Password
                DBClass.AUTHDBConnection.Close();

                // Insert user into users table
                string insertQuery = @"INSERT INTO Users (FirstName, LastName, Username, UserPassword, Email, UserType)
                                           VALUES ('" + FirstName + "','" + LastName + "','" + Username + "','" + Password + "','" + Email + "','" + UserType + "');";
                Console.WriteLine(insertQuery);

                //SqlCommand insertCommand = new SqlCommand(insertQuery, CCDBConnection);
                //insertCommand.Parameters.AddWithValue("@FirstName", FirstName);
                //insertCommand.Parameters.AddWithValue("@LastName", LastName);
                //insertCommand.Parameters.AddWithValue("@Username", Username);
                //insertCommand.Parameters.AddWithValue("@UserPassword", Password);
                //insertCommand.Parameters.AddWithValue("@Email", Email);
                //insertCommand.Parameters.AddWithValue("@UserType", UserType);

                DBClass.InsertQuery(insertQuery);
                DBClass.CCDBConnection.Close();


                TempData["SuccessMessage"] = "User created successfully.";
                return Page();

            }

            ModelState.AddModelError("Error", "Please enter information");
            TempData["FailMessage"] = "Please enter information.";
            DBClass.CCDBConnection.Close();
            ModelState.Clear(); // used to ignore validation
            return Page();
        }

        // Used to populate text fields
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear(); // used to ignore validation
            return Page();
        }

        // Used to return to the main page
        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("../Index");
        }


        // Used to clear all text fields by reloading the page
        public IActionResult OnPostClearHandler()
        {
            ModelState.Clear(); // used to ignore validation
            FirstName = null;
            LastName = null;
            Username = null;
            Password = null;
            Email = null;
            return Page();
        }
    }
}
