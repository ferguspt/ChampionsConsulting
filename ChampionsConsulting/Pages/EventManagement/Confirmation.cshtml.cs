using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class ConfirmationModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/EventManagement/CreateEvent");
        }

        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("/EventManagement/ViewEvents");
        }
    }
}
