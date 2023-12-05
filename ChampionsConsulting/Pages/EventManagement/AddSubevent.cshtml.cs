using ChampionsConsulting.Pages.DataClasses;
using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class AddSubeventModel : PageModel
    {
        [BindProperty]
        public Event CurrEvent { get; set; }

        [BindProperty]
        [Required]
        public string EventID { get; set; }
        [BindProperty]
        [Required]
        public string EventName { get; set; }
        [BindProperty]
        [Required]
        public string SubEventName { get; set; }
        [BindProperty]
        [Required]
        public string SubEventDescription { get; set; }
        [BindProperty]
        [Required]
        public DateTime StartTime { get; set; }
        [BindProperty]
        [Required]
        public DateTime EndTime { get; set; }

        public IActionResult OnGet(int EventID)
        {

            SqlDataReader EventReader = DBClass.EventReader();

            //string SelectQuery = "SELECT EventID, Name FROM Events Where EventID = " + Event + "Desc;";

            if (!EventReader.HasRows)
            {
                return RedirectToPage("/EventManagement/CreateEvent");
            }

            while (EventReader.Read())
            {
                EventID = EventReader.GetInt32(0);
                EventName = EventReader.GetString(1);
            }

            DBClass.CCDBConnection.Close();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (SubEventName == null || SubEventDescription == null || StartTime.Equals(null) || EndTime.Equals(null))
            {
                ModelState.AddModelError(string.Empty, "Try populating");
                DBClass.CCDBConnection.Close();
                return Page();
            }
            else
            {
                string insertQuery = @"INSERT INTO SubEvent (Name, Description, StartDateAndTime, EndDateAndTime, EventID) VALUES (" + "'" + SubEventName + "','" + SubEventDescription + "','" + StartTime.ToString() + "','" + EndTime.ToString() + "'," + EventID.ToString() + ");";
                DBClass.InsertQuery(insertQuery);
                TempData["SuccessMessage"] = "Sub Event created successfully.";
                DBClass.CCDBConnection.Close();
                return RedirectToPage("/EventManagement/Confirmation");
            }
        }
    }
}
