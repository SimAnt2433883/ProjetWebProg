using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjetWebProg.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User NAme is required")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "PassordHasher is required")]
        public required string Password { get; set; }
    }
}
