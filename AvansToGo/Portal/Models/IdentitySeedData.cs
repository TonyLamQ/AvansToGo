using Core.Domain;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Portal.Models
{
    public class IdentitySeedData
    {
        private const string StudentUser = "Student";
        private const string StudentPassword = "StudentPassword2@";

        private const string EmployeeUser = "Employee";
        private const string EmployeePassword = "EmployeePassword2@";


        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            IdentityUser Student = await userManager.FindByIdAsync(StudentUser);
            if (Student == null)
            {
                Student = new Student()
                {
                    UserName = "Student",
                    Email = "Student@gmail.com"
                };
                await userManager.CreateAsync(Student, StudentPassword);
                await userManager.AddClaimAsync(Student, new Claim("Student", "true"));
            }

            IdentityUser Employee = await userManager.FindByIdAsync(EmployeeUser);
            if (Employee == null)
            {
                Employee = new Employee()
                {
                    UserName = "Employee",
                    Email = "Employee@gmail.com",
                };
                await userManager.CreateAsync(Employee, EmployeePassword);
            }
        }
    }
}
