using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class CreateEventModel : PageModel
    {
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
            string CreateQuery = @"INSERT INTO Events (Name, Description, StartDateAndTime, EndDateAndTime, LocationID) VALUES (" + "'" + Name + "','" + Description + "','" + StartDateAndTime.ToString() + "','" + EndDateAndTime.ToString() + "'," + LocationID + ");";

            if (Name == null || Description == null || StartDateAndTime == null || EndDateAndTime == null || LocationID == null)
            {
                ModelState.AddModelError(string.Empty, "Try populating");
                DBClass.CCDBConnection.Close();
                return Page();
            }

            DBClass.InsertQuery(CreateQuery);
            TempData["SuccessMessage"] = "Event created successfully.";
            DBClass.CCDBConnection.Close();
            return RedirectToPage("/EventManagement/CreateEvent2", new { EventName = Name });
        }

        // Used to populate text fields
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear(); // used to ignore validation
            return Page();
        }

        //Returns admin or organizer to home page
        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("../Index");
        }

        // Used to clear all text fields by reloading the page
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
