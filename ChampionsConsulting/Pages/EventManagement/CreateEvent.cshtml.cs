using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class CreateEventModel : PageModel
    {
        [BindProperty]
        [Required]
        public String EventName { get; set; }

        [BindProperty]
        [Required]
        public String EventDescription { get; set; }

        [BindProperty]
        [Required]
        public String StartDate { get; set; }

        [BindProperty]
        [Required]
        public String EndDate { get; set; }

        [BindProperty]
        [Required]
        public String RegistrationDeadline { get; set; }

        [BindProperty]
        [Required]
        public String Capacity { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string selectQuery = "SELECT * FROM Event WHERE EventName = @EventName";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EventName", EventName),
                new SqlParameter("@EventDescription", EventDescription),
                new SqlParameter("@Capacity", Capacity)
            };

            using (SqlCommand command = new SqlCommand(selectQuery, DBClass.Lab3DBConnection))
            {
                command.Parameters.AddWithValue("@EventName", EventName);
                command.Parameters.AddWithValue("@EventDescription", EventDescription);
                command.Parameters.AddWithValue("@Capacity", Capacity);

                SqlDataReader EventReader = DBClass.EventReader(selectQuery, parameters);

                if (EventReader.HasRows)
                {
                    ModelState.AddModelError("EventName", "Event already exists.");
                    TempData["FailMessage"] = "Event already exists.";
                    DBClass.Lab3DBConnection.Close();
                    ModelState.Clear(); // Used to ignore validation
                    return Page();
                }
                if (EventName != null && EventDescription != null && Capacity != null)
                {
                    TempData["SuccessMessage"] = "Event created successfully.";
                    DBClass.Lab3DBConnection.Close();
                    ModelState.Clear(); // Used to ignore validation
                    return Page();
                }

                ModelState.AddModelError(string.Empty, "Try populating");
                DBClass.Lab3DBConnection.Close();
                return Page();
            }
        }

        // Used to populate text fields
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear(); // used to ignore validation
            return Page();
        }

        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("Index");
        }

        // Used to clear all text fields by reloading the page
        public IActionResult OnPostClearHandler()
        {
            ModelState.Clear(); // used to ignore validation
            EventName = null;
            EventDescription = null;
            StartDate = null;
            EndDate = null;
            RegistrationDeadline = null;
            Capacity = null;

            return Page();
        }
    }
}
