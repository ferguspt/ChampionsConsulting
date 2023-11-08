using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class CreateEvent2Model : PageModel
    {
        [BindProperty]
        [Required]
        public String MeetingName { get; set; }

        [BindProperty]
        [Required]
        public String MeetingDescription { get; set; }

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
        public String MeetingType { get; set; }

        public List<SelectListItem>? Meetings { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string selectQuery = $"SELECT * FROM Meeting WHERE MeetingName = '{MeetingName}'";
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
            if (MeetingName != null && MeetingDescription != null && StartTime != null && EndTime != null)
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
            return RedirectToPage("/EventManagement/CreateEvent");
        }

        // Used to clear all text fields by reloading the page
        public IActionResult OnPostClearHandler()
        {
            ModelState.Clear(); // used to ignore validation
            MeetingName = null;
            MeetingDescription = null;
            StartTime = null;
            EndTime = null;
            RoomID = null;
            MeetingType = null;

            return Page();
        }
    }
}