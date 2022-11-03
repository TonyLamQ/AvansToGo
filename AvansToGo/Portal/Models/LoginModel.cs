using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [UIHint("password")]
        public string Password { get; set; } = null!;

        public string ReturnUrl { get; set; } = "/";
    }
}
