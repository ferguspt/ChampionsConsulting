using ChampionsConsulting.Pages.DB;
using ChampionsConsulting.Pages.DataClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class EventSignUpModel : PageModel
    {
        [BindProperty]
        [Required]
        public int EventID { get; set; }
        public List<SelectListItem> EventList { get; set; }

        public EventSignUpModel()
        {
            EventList = new List<SelectListItem>();
        }

        public void OnGet()
        {
            SqlDataReader EventReader = DBClass.EventReader();

            while (EventReader.Read())
            {
                EventList.Add(new SelectListItem(
                    EventReader["Name"].ToString(),
                    EventReader["EventID"].ToString()
                    ));
            }
            DBClass.CCDBConnection.Close();
        }
    }
}
