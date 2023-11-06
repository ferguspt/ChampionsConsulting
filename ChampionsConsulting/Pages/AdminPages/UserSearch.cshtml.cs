using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.AdminPages
{
    public class UserInfoModel : PageModel
    {
        [BindProperty]
        public int UserID { get; set; }

        [BindProperty]
        public List<SelectListItem>? Users { get; set; }

        public void OnGet()
        {
            SqlDataReader UserReader = DBClass.UserReader();

            Users = new List<SelectListItem>();

            while (UserReader.Read())
            {
                Users.Add(
                    new SelectListItem(
                        UserReader["Username"].ToString(),
                        UserReader["UserID"].ToString()));
            }

            DBClass.Lab3DBConnection.Close();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/AdminPages/UserInfo", new { UserID });
        }

        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("../Index");
        }
    }
}
