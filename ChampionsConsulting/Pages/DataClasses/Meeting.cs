namespace ChampionsConsulting.Pages.DataClasses
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        public String MeetingName { get; set; }
        public String MeetingDescription { get; set; }
        public DateTime MeetingDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public String MeetingType { get; set; }
        public String MeetingStatus { get; set; }
        public int EventID { get; set; }
        public int RoomID { get; set; }
    }
}
