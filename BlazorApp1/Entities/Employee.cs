using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Entities
{
    public class Employee 
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public int Wage { get; set; }
        public DateOnly StartDate { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
