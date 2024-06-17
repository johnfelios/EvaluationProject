namespace BlazorApp1.Entities
{
    public class CourseTimeSlot
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }

}
