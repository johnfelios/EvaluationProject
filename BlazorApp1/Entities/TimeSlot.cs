namespace BlazorApp1.Entities
{
    public class TimeSlot
    {
        public int TimeSlotId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
