using Microsoft.AspNetCore.Mvc;
using ChampionsConsulting.Pages.DB;
using ChampionsConsulting.Pages.DataClasses;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public int EventID { get; set; }

        [BindProperty]
        public string Name { get; set; }

        // Other properties as needed

        public IActionResult OnGet(int EventID)
        {
            if (HttpContext.Session.GetString("UserType") != "Organizer")
            {
                return RedirectToPage("/Login/UserLogin");
            }
            else
            {
                SqlDataReader eventReader = DBClass.SingleEventReader(EventID);

                if (eventReader.Read())
                {
                    this.EventID = EventID;
                    Name = eventReader["Name"].ToString();
                    // Set other properties as needed
                }
                DBClass.CCDBConnection.Close();
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            Event eventToDelete = new Event
            {
                EventID = this.EventID,
                Name = this.Name
                // Set other properties as needed
            };

            DBClass.DeleteEvent(eventToDelete);
            DBClass.CCDBConnection.Close();
            TempData["DeletedEventSuccess"] = "Event Deleted Successfully";
            return RedirectToPage("/EventManagement/ViewEvents");
        }
    }
}
