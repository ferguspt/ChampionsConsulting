namespace ChampionsConsulting.Pages.DataClasses
{
    public class Event
    {
        public String EventID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime StartDateAndTime { get; set; }
        public DateTime EndDateAndTime { get; set; }
        public int LocationID { get; set; }
    }

}
