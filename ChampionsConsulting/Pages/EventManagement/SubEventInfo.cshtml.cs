using ChampionsConsulting.Pages.DataClasses;
using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class SubEventInfoModel : PageModel
    {
        [BindProperty]
        public Event CurrEvent { get; set; }

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

        public SubEventInfoModel()
        {
            CurrEvent = new Event();
        }

        public IActionResult OnGet(int EventID)
        {
            string getEventCommand = @"Select Name, Description, StartDateAndTime, EndDateAndTime, LocationID 
                FROM Events WHERE EventID = " + EventID + ";";

                //SqlDataReader currEventReader = DBClass.EventReader(getEvent);
                SqlDataReader getEvent = DBClass.SingleEventReader(EventID);

                while (getEvent.Read())
                {
                    CurrEvent.EventID = EventID;
                    CurrEvent.Name = getEvent["Name"].ToString();
                    CurrEvent.Description = getEvent["Description"].ToString();
                    CurrEvent.StartDateAndTime = DateTime.Parse(getEvent["StartDateAndTime"].ToString());
                    CurrEvent.EndDateAndTime = DateTime.Parse(getEvent["EndDateAndTime"].ToString());
                    CurrEvent.LocationID = Int32.Parse(getEvent["LocationID"].ToString());
                }

                DBClass.CCDBConnection.Close();
                return Page();
            }
        }
     }

