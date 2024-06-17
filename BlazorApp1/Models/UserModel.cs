using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string UserType {  get; set; }
    }
}
