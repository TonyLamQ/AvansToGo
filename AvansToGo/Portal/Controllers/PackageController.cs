using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class PackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
