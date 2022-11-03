using Core.Domain.Services.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using System.Diagnostics;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPackageRepo _PackageRepo;


        public HomeController(
            ILogger<HomeController> logger,
            IPackageRepo PackageRepo
            )
        {
            _logger = logger;
            _PackageRepo = PackageRepo;

        }

        public IActionResult Index()
        {
            return View(_PackageRepo.GetUnReservedPackages());
        }

        [Authorize(Policy = "StudentOnly")]
        public IActionResult Testing()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}