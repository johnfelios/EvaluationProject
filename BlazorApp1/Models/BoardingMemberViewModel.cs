using BlazorApp1.Entities;

namespace BlazorApp1.Models
{
    public class BoardingMemberViewModel
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public int Age { get; set; }
        public int Wage { get; set; }
        public DateOnly StartDate { get; set; }
        public BoardMemberPosition Position { get; set; }
        public int YearsOfService { get; set; }
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

   

 
}