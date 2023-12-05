using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class CreateSubEvent : PageModel
    {
        [BindProperty]
        public int EventID { get; set; }

        [BindProperty]
        public string SelectQuery { get; set; }

        public List<SelectListItem>? Events { get; set; }

        int EventListSize = 0;

        // Gets all the events from the DB
        public void OnGet()
        {
            SqlDataReader EventReader = DBClass.EventReader();

            Events = new List<SelectListItem>();

            while (EventReader.Read())
            {
                Events.Add(
                    new SelectListItem(
                        EventReader["Name"].ToString(),
                        EventReader["EventID"].ToString()));
                EventListSize++;
            }

            DBClass.CCDBConnection.Close();
        }

        public IActionResult OnPost()
        {
            // If statement for when the user chooses a event
            if (EventID >= 1 && EventID <= EventListSize)
            {
                SelectQuery = "SELECT EventID, Name, Description, StartDateAndTime FROM Events WHERE EventID = " + EventID;

                DBClass.SubEventReader(SelectQuery);

                DBClass.CCDBConnection.Close();

                return RedirectToPage("/EventManagement/CreateSubEvent2");
            }

            // If user clicks "Submit" without choosing a choice
            else
            {
                TempData["ErrorMessage"] = "Please select a choice!";
                OnGet();
                return Page();
            }
        }

        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("../Index");
        }
    }
}
