using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class CreateEventModel : PageModel
    {
        [BindProperty]
        [Required]
        public String EventName { get; set; }

        [BindProperty]
        [Required]
        public String EventDescription { get; set; }

        [BindProperty]
        [Required]
        public DateTime StartDateAndTime { get; set; }

        [BindProperty]
        [Required]
        public DateTime EndDateAndTime { get; set; }

        [BindProperty]
        [Required]
        public String LocationID { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            //string CreateQuery = $"SELECT * FROM Event WHERE MeetingName = '{EventName}'";
            string CreateQuery = $"INSERT INTO Event VALUES ({EventName},{EventDescription}," +
                $"{StartDateAndTime},{EndDateAndTime},{LocationID});";

            //SqlCommand cmdCreateEvent = new SqlCommand();
            SqlDataAdapter cmdCreateEventAdapter = new SqlDataAdapter();
            SqlCommand cmdCreateEventCommand = new SqlCommand(CreateQuery, DBClass.CCDBConnection);
            //cmdCreateEvent.Connection = DBClass.CCDBConnection;
            cmdCreateEventCommand.Connection.ConnectionString = DBClass.CCConnString;
            cmdCreateEventCommand.Connection.Open();

            

            if (cmdCreateEventCommand.ExecuteNonQuery() == 1)
            {
                cmdCreateEventCommand.Connection.Close();
            }



            SqlDataReader MeetingReader = DBClass.MeetingReader(CreateQuery);

            if (MeetingReader.HasRows)
            {
                ModelState.AddModelError("MeetingName", "Meeting already exists.");
                TempData["FailMessage"] = "Meeting already exists.";
                DBClass.CCDBConnection.Close();
                ModelState.Clear(); // used to ignore validation
                return Page();
            }

            // If the event name is unique, proceed to create the event
            if (EventName != null && EventDescription != null && StartDateAndTime != null && EndDateAndTime != null)
            {
                TempData["SuccessMessage"] = "Event created successfully.";
                DBClass.CCDBConnection.Close();
                ModelState.Clear(); // used to ignore validation
                return Page();
            }

            // Input validation
            ModelState.AddModelError(string.Empty, "Try populating");
            DBClass.CCDBConnection.Close();
            return Page();
        }

        // Used to populate text fields
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear(); // used to ignore validation
            return Page();
        }

        //Returns admin or organizer to home page
        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("../Index");
        }

        // Used to clear all text fields by reloading the page
        public IActionResult OnPostClearHandler()
        {
            ModelState.Clear(); // used to ignore validation
            EventName = null;
            EventDescription = null;
            StartDateAndTime = DateTime.MinValue;
            EndDateAndTime = DateTime.MaxValue;
            LocationID = null;

            return Page();
        }
    }
}
