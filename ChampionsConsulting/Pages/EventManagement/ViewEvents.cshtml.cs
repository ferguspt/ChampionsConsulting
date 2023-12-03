using ChampionsConsulting.Pages.DataClasses;
using ChampionsConsulting.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.EventManagement
{
    public class ViewEventsModel : PageModel
    {
        public List<Event> EventList { get; set; }

        public ViewEventsModel()

        {

            EventList = new List<Event>();

        }



        public void OnGet()

        {

            string GetEvents = @"Select EventID, Name, Description, StartDateAndTime, EndDateAndTime, Place  

                FROM Events Inner Join Location ON Events.LocationId = Location.LocationID;";



            SqlDataReader getEvents = DBClass.EventReader(GetEvents);



            while (getEvents.Read())

            {

                EventList.Add(new Event

                {

                    EventID = Int32.Parse(getEvents["EventID"].ToString()),

                    Name = getEvents["Name"].ToString(),

                    Description = getEvents["Description"].ToString(),

                    StartDateAndTime = DateTime.Parse(getEvents["StartDateAndTime"].ToString()),

                    EndDateAndTime = DateTime.Parse(getEvents["EndDateAndTime"].ToString()),

                });

            }

            DBClass.CCDBConnection.Close();

        }

    }

}

