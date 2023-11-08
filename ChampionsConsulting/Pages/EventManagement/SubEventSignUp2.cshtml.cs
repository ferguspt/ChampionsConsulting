using ChampionsConsulting.Pages.DB;
using ChampionsConsulting.Pages.DataClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class SubEventSignUp2Model : PageModel
    {
        [BindProperty]
        public int MeetingID { get; set; }

        [BindProperty]
        public List<int> Checked { get; set; }

        [BindProperty]
        public Boolean AttendMeeting { get; set; }

        [BindProperty]
        public List<Meeting> Meetings { get; set; }

        public SubEventSignUp2Model()
        {
            Meetings = new List<Meeting>();
        }

        // Grabs the presentations from the event that is chosen
        public void OnGet(string SelectQuery)
        {
            SqlDataReader meetingReader = DBClass.MeetingReader(SelectQuery);

            while (meetingReader.Read())
            {
                Meetings.Add(new Meeting
                {
                    MeetingName = meetingReader["MeetingName"].ToString(),
                    MeetingDescription = meetingReader["MeetingDescription"].ToString(),
                    MeetingID = Int32.Parse(meetingReader["MeetingID"].ToString()),
                    MeetingDate = DateTime.Parse(meetingReader["MeetingDate"].ToString())
                });
            }
            DBClass.Lab3DBConnection.Close();
        }

        // Redirects to display what presentations are signed up for
        public IActionResult OnPost(string SelectQuery)
        {
            return RedirectToPage("/EventManagement/SubEventSignUpSummary", new { Checked });
        }
    }
}
