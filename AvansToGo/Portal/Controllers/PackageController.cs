using Core.Domain;
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
        private readonly IProductRepo _ProductRepo;


        public PackageController(
            ILogger<PackageController> logger,
            IPackageRepo PackageRepo,
             IStudentRepo StudentRepo,
             IProductRepo ProductRepo
            )
        {
            _logger = logger;
            _PackageRepo = PackageRepo;
            _StudentRepo = StudentRepo;
            _ProductRepo = ProductRepo;

        }
        public IActionResult Index()
        {
            return View(_PackageRepo.GetAll().ToViewModel());
        }

        public IActionResult CreatePackage()
        {
            var Prod = _ProductRepo.GetAll().ToList();

            var Pack = new PackageViewModel();
            Pack.Checkboxes = new List<ProductCheckboxOptions>();
            Pack.Products = new List<Product>();
            foreach(var p in Prod)
            {
                var Product = new Product();
                Product.Name = p.Name;
                Product.ImageUrl = p.ImageUrl;
                Product.ContainsAlcohol = p.ContainsAlcohol;

                var Checkbox = new ProductCheckboxOptions
                {
                    IsChecked = true,
                    Value = new Product()
                };
                Checkbox.Value = Product;

                if(Checkbox == null)
                {

                } else
                {
                    Pack.Checkboxes.Add(Checkbox);
                }
            }
            
            return View(Pack);
        }
        [HttpPost]
        public async Task<ActionResult> CreatePackage(PackageViewModel package)
        {
            if (ModelState.IsValid)
            {
                //var AddPackageResult = _PackageRepo.AddPackage(package);

                //await AddPackageResult;

                //if (AddPackageResult.IsCompletedSuccessfully)
                //{
                //    //Show Popup Success
                //}
            }
            return View("Index");
            //ModelState.AddModelError("", "Invalid Package");
            //return View(package);
        }
    }
}
