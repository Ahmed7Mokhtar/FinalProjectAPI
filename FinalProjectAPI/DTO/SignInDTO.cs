using System.ComponentModel.DataAnnotations;

namespace FinalProjectAPI.DTO
{
    public class SignInDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
