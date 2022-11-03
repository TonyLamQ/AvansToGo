using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Employee : IdentityUser
    {
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
    }
}
