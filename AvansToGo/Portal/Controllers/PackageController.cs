using Core.Domain.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;

namespace Portal.Controllers
{
    public class PackageController : Controller
    {
        private readonly ILogger<PackageController> _logger;
        private readonly IPackageRepo _PackageRepo;
        private readonly IStudentRepo _StudentRepo;


        public PackageController(
            ILogger<PackageController> logger,
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
            return View(_PackageRepo.GetAll().ToViewModel());
        }
    }
}
