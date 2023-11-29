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
            //string SelectQuery = "SELECT  " +
            //"Events.Name, Location.LocationName, SubEvent.Name, SubEvent.Description, SubEvent.StartDateAndTime, " +
            //"SubEvent.EndDateAndTime FROM [User] INNER JOIN Events ON [User].UserID = Events.UserID " +
            //"INNER JOIN Events ON Events.EventID = Event.EventID INNER JOIN Location ON Events.LocationID = Location.LocationID " +
            //"INNER JOIN Meeting ON Event.EventID = Meeting.EventID " +
            //"WHERE [User].Username = '" + HttpContext.Session.GetString("Username") + "'";

            string SelectQuery = "SELECT E.Name, L.Place, SE.Name, SE.Description, SE.StartDateAndTime, SE.EndDateAndTime" +
                "FROM Events E, Location L, SubEvent SE, Users U, AttendEvent AE" +
                "WHERE E.EventID = AE.EventID AND U.UserID = AE.UserID";

            //SqlDataReader dataReader = DBClass.UserReader(SelectQuery);

            /*while (dataReader.Read())
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
            DBClass.CCDBConnection.Close();*/
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Index");
        }
    }
}
