using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Student : IdentityUser
    {
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        public EnumCity City { get; set; }
        public string? PhoneNumber { get; set; }
    }
}