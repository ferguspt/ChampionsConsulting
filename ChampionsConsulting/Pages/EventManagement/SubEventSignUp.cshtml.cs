using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class SubEventSignUpModel : PageModel
    {
        [BindProperty]
        public int EventID { get; set; }

        [BindProperty]
        public string SelectQuery { get; set; }

        public List<SelectListItem>? Events { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToPage("/Login/UserLogin");
            }
            else
            {
                SqlDataReader EventReader = DBClass.EventReader();

                Events = new List<SelectListItem>();

                while (EventReader.Read())
                {
                    Events.Add(
                        new SelectListItem(
                            EventReader["Name"].ToString(),
                            EventReader["EventID"].ToString()));
                }

                DBClass.CCDBConnection.Close();
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            // If statement for when the user chooses a event
            if (EventID >= 1 && EventID < Events.Count)
            {
                SelectQuery = "SELECT SubEventID, Name, Description, StartDateAndTime, EndDateAndTime FROM SubEvent WHERE EventID = " + EventID;

                DBClass.MeetingReader(SelectQuery);

                DBClass.CCDBConnection.Close();

                return RedirectToPage("/EventManagement/SubEventSignUp2", new { SelectQuery });
            }

            // If user clicks "Submit" without choosing a choice
            else
            {
                TempData["ErrorMessage"] = "For the test please select a choice!";
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
