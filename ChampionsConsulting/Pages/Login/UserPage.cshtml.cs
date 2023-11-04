using ChampionsConsulting.Pages.DB;
using ChampionsConsulting.Pages.DataClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.Login
{
    public class UserPageModel : PageModel
    {
        [BindProperty]
        public List<UserDataAll> Data { get; set; }

        public UserPageModel()
        {
            Data = new List<UserDataAll>();
        }

        public void OnGet()
        {
            string SelectQuery = "SELECT  " +
            "Event.EventName, Location.LocationName, Event.EventStatus, Meeting.MeetingName, Meeting.MeetingDate, " +
            "Meeting.MeetingType, Meeting.MeetingStatus FROM [User] INNER JOIN EventAttendance ON [User].UserID = EventAttendance.UserID " +
            "INNER JOIN Event ON EventAttendance.EventID = Event.EventID INNER JOIN Location ON Event.LocationID = Location.LocationID " +
            "INNER JOIN Meeting ON Event.EventID = Meeting.EventID " +
            "WHERE [User].Username = '" + HttpContext.Session.GetString("Username") + "'";

            SqlDataReader dataReader = DBClass.UserReader(SelectQuery);

            while (dataReader.Read())
            {
                Data.Add(new UserDataAll
                {
                    // All event and presentation data that the user is signed up for
                    EventName = dataReader["EventName"].ToString(),
                    LocationName = dataReader["LocationName"].ToString(),
                    EventStatus = dataReader["EventStatus"].ToString(),
                    MeetingName = dataReader["MeetingName"].ToString(),
                    MeetingDate = DateTime.Parse(dataReader["MeetingDate"].ToString()),
                    MeetingType = dataReader["MeetingType"].ToString(),
                    MeetingStatus = dataReader["MeetingStatus"].ToString()
                });
            }
            DBClass.Lab3DBConnection.Close();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Index");
        }
    }
}
