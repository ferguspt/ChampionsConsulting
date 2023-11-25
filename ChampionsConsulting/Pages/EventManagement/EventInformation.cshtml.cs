using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class EventInformationModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToPage("/Login/UserLogin");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPostEditHandler()
        {
            return RedirectToPage("/Edit");
        }

        public IActionResult OnPostDeleteHandler()
        {
            return RedirectToPage("/Search");
        }
    }
}
