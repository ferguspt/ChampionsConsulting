using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.AdminPages
{
    public class UserInfoModel : PageModel
    {
        [BindProperty]
        public int UserID { get; set; }

        [BindProperty]
        [Required]
        public string Username { get; set; }

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
            HttpContext.Session.SetString("username", Username);
            DBClass.CCDBConnection.Close();
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
