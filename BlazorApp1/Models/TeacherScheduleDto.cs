namespace BlazorApp1.Models
{
    public class TeacherScheduleDto
    {
        public string CourseTitle { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
