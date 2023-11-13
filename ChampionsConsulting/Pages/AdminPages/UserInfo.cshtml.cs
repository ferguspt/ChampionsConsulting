using ChampionsConsulting.Pages.DataClasses;
using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.AdminPages
{
    public class UserSearchModel : PageModel
    {
        public string SelectQuery { get; set; }

        [BindProperty]
        public List<UserDataAll> Data { get; set; }

        public UserSearchModel()
        {
            Data = new List<UserDataAll>();
        }

        public void OnGet(int userID)
        {
            SelectQuery = "SELECT Users.FirstName, Users.LastName, Users.Email, Users.Phone, Users.Username, " +
            "Users.UserType, Event.Name, SubEvent.Name, SubEvent.StartDateAndTime, " +
            "FROM Users INNER JOIN EventAttendance ON [User].UserID = EventAttendance.UserID " +
            "INNER JOIN Event ON EventAttendance.EventID = Event.EventID INNER JOIN Location ON Event.LocationID = Location.LocationID " +
            "INNER JOIN Meeting ON Event.EventID = Meeting.EventID " +
            "WHERE [User].userID = " + userID;

            SqlDataReader dataReader = DBClass.UserReader(SelectQuery);

            while (dataReader.Read())
            {
                Data.Add(new UserDataAll
                {
                    // All user data  
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    Email = dataReader["Email"].ToString(),
                    PhoneNumber = dataReader["PhoneNumber"].ToString(),
                    Username = dataReader["Username"].ToString(),
                    UserType = dataReader["UserType"].ToString(),

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
            DBClass.CCDBConnection.Close();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("../Index");
        }
    }
}
