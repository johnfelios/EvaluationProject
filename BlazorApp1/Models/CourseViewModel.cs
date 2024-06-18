namespace BlazorApp1.Models
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public  string CourseTitle { get; set; }
        public int TeacherAccountId { get; set; }
        public TimeSlotDto TimeSlot { get; set; }
    }
}
