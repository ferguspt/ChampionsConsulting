using ChampionsConsulting.Pages.DataClasses;
using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class SearchResultModel : PageModel
    {
        [BindProperty]
        public List<UserDataAll> Data { get; set; }

        public SearchResultModel()
        {
            Data = new List<UserDataAll>();
        }
        public void OnGet(string Keyword, string Presenter)
        {
            string searchQuery = "SELECT concat_ws(' ', FirstName, LastName) as FullName, Event.EventName, Meeting.MeetingName, Meeting.MeetingDescription, Meeting.MeetingDate " +
                                "FROM Event INNER JOIN Meeting ON Event.EventID = Meeting.EventID INNER JOIN MeetingAttendance ON Meeting.MeetingID = MeetingAttendance.MeetingID INNER JOIN " +
                                "[User] ON MeetingAttendance.UserID = [User].UserID WHERE EventDescription " +
                                "LIKE '%" + Keyword + "%' AND concat_ws(' ', FirstName, LastName) LIKE '%" + Presenter + "%'";

            SqlDataReader reader = DBClass.SubEventReader(searchQuery);

            while (reader.Read())
            {
                Data.Add(new UserDataAll
                {
                    FirstName = reader["FullName"].ToString(),
                    EventName = reader["EventName"].ToString(),
                    MeetingName = reader["MeetingName"].ToString(),
                    MeetingDescription = reader["MeetingDescription"].ToString(),
                    MeetingDate = DateTime.Parse(reader["MeetingDate"].ToString())

                });
            }
            DBClass.CCDBConnection.Close();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Search");
        }
    }
}
