using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class CreateSubEventModel : PageModel
    {
        [BindProperty]
        [Required]
        public String SubEventName { get; set; }

        [BindProperty]
        [Required]
        public String SubEventDescription { get; set; }

        [BindProperty]
        [Required]
        public String StartTime { get; set; }

        [BindProperty]
        [Required]
        public String EndTime { get; set; }

        [BindProperty]
        [Required]
        public String EventID { get; set; }

        [BindProperty]
        [Required]
        public String RoomID { get; set; }

        [BindProperty]
        [Required]
        public String SubEventType { get; set; }

        public List<SelectListItem>? SubEvents { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string selectQuery = $"SELECT * FROM Meeting WHERE MeetingName = '{SubEventName}'";
            SqlDataReader MeetingReader = DBClass.MeetingReader(selectQuery);

            if (MeetingReader.HasRows)
            {
                ModelState.AddModelError("MeetingName", "Meeting already exists.");
                TempData["FailMessage"] = "Meeting already exists.";
                DBClass.Lab3DBConnection.Close();
                ModelState.Clear(); // used to ignore validation
                return Page();
            }

            // If the event name is unique, proceed to create the event
            if (SubEventName != null && SubEventDescription != null && StartTime != null && EndTime != null)
            {
                TempData["SuccessMessage"] = "Event created successfully.";
                DBClass.Lab3DBConnection.Close();
                ModelState.Clear(); // used to ignore validation
                return Page();
            }

            // Input validation
            ModelState.AddModelError(string.Empty, "Try populating");
            DBClass.Lab3DBConnection.Close();
            return Page();
        }

        // Used to populate text fields
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear(); // used to ignore validation
            return Page();
        }

        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("ChooseConference");
        }

        // Used to clear all text fields by reloading the page
        public IActionResult OnPostClearHandler()
        {
            ModelState.Clear(); // used to ignore validation
            SubEventName = null;
            SubEventDescription = null;
            StartTime = null;
            EndTime = null;
            RoomID = null;
            SubEventType = null;

            return Page();
        }
    }
}
