using BlazorApp1.Entities;

namespace BlazorApp1.Models
{
    public class TeacherViewModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public int Wage { get; set; }
        public DateOnly StartDate { get; set; }
    }
}
