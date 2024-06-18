using BlazorApp1.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class StudentViewModel
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public int Age { get; set; }
        public DateOnly StartDate { get; set; }
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}