using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class CheckInModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostCheckInHandler()
        {
            return Page();
        }

        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("../Index");
        }
    }
}
