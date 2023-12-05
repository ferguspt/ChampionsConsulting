using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages
{
    public class FeedbackModel : PageModel
    {
        // Define properties to bind with form fields
        [BindProperty]
        public string EventName { get; set; }

        [BindProperty]
        public string Feedback { get; set; }

        [BindProperty]
        public int EventId { get; set; }

        [BindProperty]
        public int UserID { get; set; }

        public List<SelectListItem>? EventOptions { get; set; }


        public IActionResult OnGet(String username)
        {
            // Check if the user is logged in or authorized to access this feature
            if (HttpContext.Session.GetString("Username") == null)
            {
                // Redirect to the login page if the user is not logged in
                return RedirectToPage("/Login/UserLogin");
            }
            else
            {
                
                var username2 = HttpContext.Session.GetString("Username");
               
                // Query to fetch attended events based on UserID
                string query = @"
                    SELECT Events.EventID, Events.Name, Events.Description, Events.StartDateAndTime, Events.EndDateAndTime, Events.LocationID 
                    FROM Events
                    INNER JOIN AttendEvent ON Events.EventID = AttendEvent.EventID
                    INNER JOIN Users ON AttendEvent.UserID = Users.UserID
                    WHERE Users.username = '" + username2 + "';";


                SqlDataReader EventReader = DBClass.EventReader(query);
                
                EventOptions = new List<SelectListItem>();

                while (EventReader.Read())
                {
                    EventOptions.Add(new SelectListItem(
                      EventReader["Name"].ToString(),
                      EventReader["EventId"].ToString()
                    ));
                }

                DBClass.CCDBConnection.Close(); // Close the database connection


                return Page();
            }
        }



        public IActionResult OnPost()
        {
            if (Feedback == null || EventName == null)
            {
                return Page();
            }

            string insertFeedbackQuery = $"INSERT INTO Feedback (EventID, FeedbackText) VALUES (" + EventId + ",'" + Feedback + "')";

            DBClass.InsertQuery(insertFeedbackQuery);
            DBClass.CCDBConnection.Close(); // Close the database connection

            TempData["FeedbackSuccessMessage"] = "Feedback submitted successfully.";
            return RedirectToPage("../Index"); // Redirect after submitting feedback
        }
    }
}
