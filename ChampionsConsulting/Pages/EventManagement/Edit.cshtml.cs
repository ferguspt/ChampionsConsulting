using Microsoft.AspNetCore.Mvc;
using ChampionsConsulting.Pages.DB;
using ChampionsConsulting.Pages.DataClasses;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public Event NewEvent { get; set; }

        public List<SelectListItem> Event { get; set; }

        [BindProperty]
        [Required]
        public String Name { get; set; }

        [BindProperty]
        [Required]
        public String Description { get; set; }

        [BindProperty]
        [Required]
        public DateTime StartDateAndTime { get; set; }

        [BindProperty]
        [Required]
        public DateTime EndDateAndTime { get; set; }

        [BindProperty]
        [Required]
        public String LocationID { get; set; }
        [BindProperty]
        public List<SelectListItem>? Location { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToPage("/Login/UserLogin");
            }
            else
            {
                SqlDataReader LocationReader = DBClass.LocationReader();

                Location = new List<SelectListItem>();

                while (LocationReader.Read())
                {
                    Location.Add(new SelectListItem(
                        LocationReader["Place"].ToString(),
                        LocationReader["LocationID"].ToString()
                        ));
                }

                DBClass.CCDBConnection.Close();
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                DBClass.UpdateEvent(NewEvent);
                DBClass.CCDBConnection.Close();
                return RedirectToPage("/Events/UpdatedEventInfo");
            }
            else
            {
                return Page();
            }

        }

        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("../Index");
        }

        public IActionResult OnPostClearHandler()
        {
            ModelState.Clear(); // used to ignore validation
            Name = null;
            Description = null;
            StartDateAndTime = DateTime.MinValue;
            EndDateAndTime = DateTime.MaxValue;
            LocationID = null;

            return Page();
        }
    }
}
