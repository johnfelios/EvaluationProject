using BlazorApp1.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class StudentViewModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public DateOnly StartDate { get; set; }

    }
}