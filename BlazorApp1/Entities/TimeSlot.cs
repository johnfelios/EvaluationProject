namespace BlazorApp1.Entities
{
    //TimeSlot Class so created objects Timeslots can be used for Courses and Cleaning Timeslots
    public class TimeSlot
    {
        public int TimeSlotId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
