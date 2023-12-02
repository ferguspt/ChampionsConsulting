using ChampionsConsulting.Pages.DataClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChampionsConsulting.Pages.AdminPages
{
    public class UserInformationModel : PageModel
    {
        [BindProperty]
        public List<UserDataAll> Data { get; set; }

        public UserInformationModel()
        {
            Data = new List<UserDataAll>();
        }
        public void OnGet()
        {
        }
    }
}
