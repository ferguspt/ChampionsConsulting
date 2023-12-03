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
        public Event CurrEventToUpdate { get; set; }

        [BindProperty]
        [Required]
        public string EventID { get; set; }

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

        public EditModel()
        {
            CurrEventToUpdate = new Event();
        }

        public IActionResult OnGet(int EventID)
        {
            string getEventCommand = @"Select Name, Description, StartDateAndTime, EndDateAndTime, LocationID 
                FROM Events WHERE EventID = " + EventID + ";";

            if (HttpContext.Session.GetString("UserType") != "Organizer")
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

                //SqlDataReader currEventReader = DBClass.EventReader(getEvent);
                SqlDataReader getEvent = DBClass.SingleEventReader(EventID);

                while (getEvent.Read())
                {
                    CurrEventToUpdate.EventID = EventID;
                    CurrEventToUpdate.Name = getEvent["Name"].ToString();
                    CurrEventToUpdate.Description = getEvent["Description"].ToString();
                    CurrEventToUpdate.StartDateAndTime = DateTime.Parse(getEvent["StartDateAndTime"].ToString());
                    CurrEventToUpdate.EndDateAndTime = DateTime.Parse(getEvent["EndDateAndTime"].ToString());
                    CurrEventToUpdate.LocationID = Int32.Parse(getEvent["LocationID"].ToString());
                }

                DBClass.CCDBConnection.Close();
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            DBClass.UpdateEvent(CurrEventToUpdate);
            DBClass.CCDBConnection.Close();
            TempData["UpdatedEventSuccess"] = "Event Updated Successfully";
            return Page();
        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear(); // used to ignore validation
            return Page();
        }

        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("/EventManagement/ViewEvents");
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
