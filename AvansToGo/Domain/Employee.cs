using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CanteenLocation { get; set; } = null!;
    }
}
