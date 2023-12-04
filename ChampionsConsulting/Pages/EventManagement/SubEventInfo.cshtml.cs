using ChampionsConsulting.Pages.DataClasses;
using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;


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
            CurrEvent.EventID = EventID;
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

        public async Task<IActionResult> OnPostDownloadUserListAsync()
        {
            var users = GetUsersForEvent(CurrEvent.EventID);
            var csv = GenerateCsv(users);
            var fileName = $"Event-{CurrEvent.EventID}-UserList.csv";
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", fileName);
        }

        private IEnumerable<UserDataAll> GetUsersForEvent(int EventId)
        {
            List<UserDataAll> users = new List<UserDataAll>();
            string query = @"SELECT Users.* FROM Users
                         JOIN AttendEvent ON Users.UserID = AttendEvent.UserID
                         WHERE AttendEvent.EventID = @EventID";

            using (var command = new SqlCommand(query, DBClass.CCDBConnection))
            {
                command.Parameters.AddWithValue("@EventID", EventId);
                DBClass.CCDBConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new UserDataAll
                        {
                            // Assume User has properties like UserId, Username, etc.

                            Username = reader.GetString(reader.GetOrdinal("Username")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone"))
                            
                        };
                        users.Add(user);
                    }
                }
                DBClass.CCDBConnection.Close();
            }
            return users;
        }

        private string GenerateCsv(IEnumerable<UserDataAll> users)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Check-In, Username, FirstName, LastName, Email, PhoneNumber"); 

            foreach (var user in users)
            {
                sb.AppendLine($" , {user.Username},{user.FirstName}, {user.LastName}, {user.Email}, {user.Phone}"); 
            }

            return sb.ToString();
        }
    }
}

