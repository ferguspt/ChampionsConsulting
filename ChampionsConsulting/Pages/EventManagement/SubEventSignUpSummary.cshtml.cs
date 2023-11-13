using ChampionsConsulting.Pages.DB;
using ChampionsConsulting.Pages.DataClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class SubEventSignUpSummaryModel : PageModel
    {
        public string SelectQuery { get; set; }

        [BindProperty]
        public List<EventLocationMeeting> Data { get; set; }

        public SubEventSignUpSummaryModel()
        {
            Data = new List<EventLocationMeeting>();
        }
        public void OnGet(List<int> Checked)
        {
            foreach (int i in Checked)
            {
                SelectQuery = "SELECT Event.EventName, Location.LocationName, Event.EventStatus, Meeting.MeetingName, Meeting.MeetingDate, " +
                    "Meeting.MeetingType, Meeting.MeetingStatus " +
                    "FROM Event INNER JOIN Meeting ON Event.EventID = Meeting.EventID INNER JOIN " +
                    "Location ON Event.LocationID = Location.LocationID INNER JOIN " +
                    "Room ON Meeting.RoomID = Room.RoomID AND Location.LocationID = Room.LocationID " +
                    "WHERE MeetingID = " + i;

                SqlDataReader dataReader = DBClass.MeetingReader(SelectQuery);

                while (dataReader.Read())
                {
                    Data.Add(new EventLocationMeeting
                    {
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

            DBClass.CCDBConnection.Close();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("../Index");
        }
    }
}
