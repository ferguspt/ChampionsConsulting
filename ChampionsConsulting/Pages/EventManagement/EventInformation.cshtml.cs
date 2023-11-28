using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class EventInformationModel : PageModel
    {
        public List<SelectListItem>? Event { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToPage("/Login/UserLogin");
            }
            else
            {
                SqlDataReader EventReader = DBClass.EventReader();

                Event = new List<SelectListItem>();

                while (EventReader.Read())
                {
                    Event.Add(new SelectListItem(
                        EventReader["EventID"].ToString(),
                        EventReader["Name"].ToString()
                        ));
                }
                return Page();
            }

        }

        public IActionResult OnPostEditHandler()
        {
            return RedirectToPage("/Edit");
        }

        public IActionResult OnPostDeleteHandler()
        {
            return RedirectToPage("/Delete");
        }
    }
}
