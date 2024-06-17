namespace BlazorApp1.Entities
{
    public class CleanerTimeSlot
    {
        public int CleanerAccountId { get; set; }
        public Cleaner Cleaner { get; set; }

        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }
}
