using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class CreateSubEvent2Model : PageModel
    {
        [BindProperty]
        [Required]
        public String SubEventName { get; set; }

        [BindProperty]
        [Required]
        public String EventName { get; set; }

        [BindProperty]
        [Required]
        public DateTime StartTime { get; set; }

        [BindProperty]
        [Required]
        public DateTime EndTime { get; set; }

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
            string selectQuery = $"SELECT * FROM SubEvent WHERE EventID = '{EventID}'";
            SqlDataReader SubEventReader = DBClass.SubEventReader(selectQuery);

            if (SubEventReader.HasRows)
            {
                ModelState.AddModelError("MeetingName", "Meeting already exists.");
                TempData["FailMessage"] = "Meeting already exists.";
                DBClass.CCDBConnection.Close();
                ModelState.Clear(); // used to ignore validation
                return Page();
            }

            // If the event name is unique, proceed to create the event
            if (SubEventName != null && EventName != null && StartTime != null && EndTime != null)
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

        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("/EventManagement/CreateEvent");
        }

        // Used to clear all text fields by reloading the page
        public IActionResult OnPostClearHandler()
        {
            ModelState.Clear(); // used to ignore validation
            SubEventName = null;
            EventName = null;
            StartTime = null;
            EndTime = null;
            RoomID = null;
            SubEventType = null;

            return Page();
        }
    }
}
