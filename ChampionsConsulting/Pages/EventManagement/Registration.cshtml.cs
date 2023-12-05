using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Specialized;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        [Required]
        public string EventName { get; set; }
        [TempData]
        [Required]
        public int CurrUser { get; set; }
        [TempData]
        [Required]
        public int CurrEventID { get; set; }

        //Gets proper user information and event name
        public IActionResult OnGet(int EventID)
        {
            //Set Event
            CurrEventID = EventID;
            //SQL Commands
            string cmdGetUser = @"SELECT UserID FROM Users 
                WHERE Username = '" + HttpContext.Session.GetString("Username") + "';";
            string cmdGetEvent = "SELECT Name FROM Events WHERE EventID = " + EventID + ";";

            //Get User ID
            SqlDataReader GetUser = DBClass.UserReader(cmdGetUser);
            while (GetUser.Read())
            {
                CurrUser = Int32.Parse(GetUser["UserID"].ToString());
            }
            DBClass.CCDBConnection.Close();

            //Get Event Name
            SqlDataReader GetEvent = DBClass.EventReader(cmdGetEvent);
            while (GetEvent.Read())
            {
                EventName = GetEvent["Name"].ToString();
            }
            DBClass.CCDBConnection.Close();
            return Page();
        }

        //Registers the user for the event
        public IActionResult OnPost()
        {
            //Get count of event attendance
            string getCount = "SELECT COUNT(*) FROM AttendEvent WHERE UserID = " + CurrUser + " AND EventID = " + CurrEventID;
            int count = DBClass.AttendEventCount(getCount);
            //int testCount = DBClass.AttendEventCount(CurrUser, CurrEventID);
            Console.WriteLine(getCount);
            Console.WriteLine(count);
            DBClass.CCDBConnection.Close();

            if (count == 1)
            {
                Console.WriteLine("Registered for the event already");
            }
            else
            {
                string cmdRegisteredInsert = @"INSERT INTO AttendEvent (UserID,EventID) VALUES " + "(" + CurrUser + "," + CurrEventID + ")";
                Console.WriteLine(CurrUser + " " + CurrEventID);
                Console.WriteLine(cmdRegisteredInsert);
                DBClass.InsertQuery(cmdRegisteredInsert);
                DBClass.CCDBConnection.Close();
                Console.WriteLine("Registered");
            }

            DBClass.CCDBConnection.Close();
            return RedirectToPage("/EventManagement/UserPage2");
        }

        public IActionResult OnPostReturnHandler()
        {
            return RedirectToPage("/EventManagement/ViewEvents");
        }
    }
}