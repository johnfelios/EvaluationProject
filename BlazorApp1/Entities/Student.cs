using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Entities
{
    public class Student 
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public DateOnly StartDate { get; set; }
        public List<StudentCourse>? EnrolledCourses { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public Student()
        {
             EnrolledCourses = new List<StudentCourse>();  
        }
    }
}
