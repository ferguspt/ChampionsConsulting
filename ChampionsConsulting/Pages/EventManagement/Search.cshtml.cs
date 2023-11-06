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

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/SearchResult", new { Keyword, Presenter });
        }
        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("Index");
        }
    }
}
