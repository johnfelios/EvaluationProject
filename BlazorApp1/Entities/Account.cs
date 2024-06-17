using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Password { get; set; }
        public Role AccountRole { get; set; }
    }

    public enum Role
    {
        Student,
        Teacher,
        Cleaner,
        BoardingMember,
        Admin
    }
}
