using BlazorApp1.Entities;

namespace BlazorApp1.Models
{
    public class BoardingMemberViewModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public int Wage { get; set; }
        public DateOnly StartDate { get; set; }
        public BoardMemberPosition Position { get; set; }
        public int YearsOfService { get; set; }
    }
}