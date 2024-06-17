using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Entities
{
    public class Course
    {
        [Key] 
        public int CourseId { get; set; }
        public required string CourseTitle { get; set; }
        public int TeacherAccountId { get; set; }
        public List<CourseTimeSlot> CourseTimeSlots { get; set; } = new List<CourseTimeSlot>();

    }
}
