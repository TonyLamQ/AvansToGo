using Core.Domain.Services.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using System.Diagnostics;
using System.Security.Claims;
using Core.Domain;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPackageRepo _PackageRepo;
        private readonly IStudentRepo _StudentRepo;


        public HomeController(
            IPackageRepo PackageRepo,
             IStudentRepo StudentRepo
            )
        {
            _PackageRepo = PackageRepo;
            _StudentRepo = StudentRepo;

        }

        public IActionResult Index()
        {
            return View(_PackageRepo.GetUnReservedPackages());
        }
        public IActionResult PackageDetails(int id)
        {
            return View(_PackageRepo.GetPackageById(id));
        }

        [Authorize(Policy = "StudentOnly")]
        [HttpPost]
        public IActionResult ReservePackage(int id)
        {
            var Student = _StudentRepo.GetStudentByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (Student != null)
            {
                var succeeded = _PackageRepo.AddReservedById(Student.StudentId, id);
                if (!succeeded)
                {
                    TempData["AlertMessage"] = "This package has already been reserved.";
                    return View("Index", _PackageRepo.GetUnReservedPackages());
                }
            }
            else
            {
                TempData["AlertMessage"] = "You are not logged in.";
                return View("Index", _PackageRepo.GetUnReservedPackages());
            }

            return View("Index", _PackageRepo.GetUnReservedPackages());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //TestingMethods
        public bool AddReservedById(int PackageId)
        {
            //var email = User.FindFirstValue(ClaimTypes.Email);
            var email = "Student@gmail.com";
            var Student = _StudentRepo.GetStudentByEmail(email);
            if (Student != null)
            {
                var succeeded = _PackageRepo.AddReservedById(Student.StudentId, PackageId);
                if (!succeeded)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}