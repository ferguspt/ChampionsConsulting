namespace ChampionsConsulting.Pages.DataClasses
{
    public class EventLocationMeeting
    {
        public int EventID { get; set; }
        public String? EventName { get; set; }
        public String? EventDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public int Capacity { get; set; }
        public String? EventStatus { get; set; }
        public int LocationID { get; set; }
        public String? LocationName { get; set; }
        public String? City { get; set; }
        public String? State { get; set; }
        public int ZipCode { get; set; }
        public int MeetingID { get; set; }
        public String? MeetingName { get; set; }
        public String? MeetingDescription { get; set; }
        public DateTime MeetingDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public String? MeetingType { get; set; }
        public String? MeetingStatus { get; set; }
        public int RoomID { get; set; }
    }
}
