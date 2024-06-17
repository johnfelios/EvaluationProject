namespace BlazorApp1.Entities
{
    public class StudentCourse 
    {
        public int Id { get; set; }
        public int StudentAccountId { get; set; }
        public float OralMark { get; set; }
        public float WritingMark { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
