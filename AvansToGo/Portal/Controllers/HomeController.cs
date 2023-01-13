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
        private readonly ILogger<HomeController> _logger;
        private readonly IPackageRepo _PackageRepo;
        private readonly IStudentRepo _StudentRepo;


        public HomeController(
            ILogger<HomeController> logger,
            IPackageRepo PackageRepo,
             IStudentRepo StudentRepo
            )
        {
            _logger = logger;
            _PackageRepo = PackageRepo;
            _StudentRepo = StudentRepo;

        }

        public IActionResult Index()
        {
            return View(_PackageRepo.GetUnReservedPackages());
        }
        [Authorize(Policy = "StudentOnly")]
        public IActionResult List()
        {
            var Student = _StudentRepo.GetStudentByEmail(User.FindFirstValue(ClaimTypes.Email));
            return View("Index", _PackageRepo.GetReservedPackagesBy(Student));
        }

        [Authorize(Policy = "StudentOnly")]
        public IActionResult ReservePackage(Package package)
        {
            var Student = _StudentRepo.GetStudentByEmail(User.FindFirstValue(ClaimTypes.Email));
            //Insert UpdatePackageReservedBy
            
            //ToDo: Input SUcceeded PopUp
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}