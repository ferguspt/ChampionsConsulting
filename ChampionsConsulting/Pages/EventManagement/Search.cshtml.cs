using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class SearchModel : PageModel
    {
        [BindProperty]
        public string Keyword { get; set; }

        [BindProperty]
        public string Presenter { get; set; }

        public IActionResult OnGet(int UserID)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                // Redirect to the login page if the user is not logged in
                return RedirectToPage("/Login/UserLogin");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/EventManagement/SearchResult", new { Keyword, Presenter });
        }
        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("../Index");
        }
    }
}
