using Core.Domain;
using Core.Domain.Services.IRepository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal.Models;
using System.Globalization;
using System.Security.Claims;

namespace Portal.Controllers
{
    public class PackageController : Controller
    {
        private readonly IPackageRepo _PackageRepo;
        private readonly IStudentRepo? _StudentRepo;
        private readonly IProductRepo? _ProductRepo;
        private readonly IEmployeeRepo? _EmployeeRepo;
        private readonly ICanteenRepo? _CanteenRepo;


        public PackageController(
            IPackageRepo PackageRepo,
             IStudentRepo? StudentRepo,
             IProductRepo? ProductRepo,
             IEmployeeRepo? employeeRepo,
             ICanteenRepo? canteenRepo
            )
        {
            _PackageRepo = PackageRepo;
            _StudentRepo = StudentRepo;
            _ProductRepo = ProductRepo;
            _EmployeeRepo = employeeRepo;
            _CanteenRepo = canteenRepo;
        }

        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult Index()
        {
            return View(_PackageRepo.GetUnReservedPackagesFilteredDateAsc());
        }

        [Authorize(Policy = "StudentOnly")]
        public IActionResult MyPackages()
        {
            var Student = _StudentRepo.GetStudentByEmail(User.FindFirstValue(ClaimTypes.Email));
            return View(_PackageRepo.GetReservedPackagesBy(Student));
        }

        public IActionResult PackageDetails(int id)
        {
            return View(_PackageRepo.GetPackageById(id));
        }

        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult AdminPackageDetails(int id)
        {
            return View(_PackageRepo.GetPackageById(id));
        }

        [Authorize(Policy = "StudentOnly")]
        [HttpPost]
        public IActionResult UnreservePackage(int id)
        {
            var Student = _StudentRepo.GetStudentByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (Student != null)
            {
                _PackageRepo.AddUnreservedById(Student.StudentId, id);
            }
            else
            {
                throw new Exception("Something went wrong");
            }

            return View("MyPackages", _PackageRepo.GetReservedPackagesBy(Student));
        }

        [Authorize(Policy = "EmployeeOnly")]
        [HttpPost]
        public  IActionResult DeletePackage(int id)
        {
            _PackageRepo.DeletePackageById(id);
            return View("Index", _PackageRepo.GetUnReservedPackagesFilteredDateAsc());
        }

        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult CreatePackage()
        {
            var Pack = new PackageViewModel();
            Pack.Checkboxes = new List<ProductCheckboxOptions>();
            Pack.Products = new List<string>();

            var Prod = _ProductRepo.GetAll().ToList();
            foreach (var p in Prod)
            {
                var Product = new Product();
                Product.Name = p.Name;
                Product.ImageUrl = p.ImageUrl;
                Product.ContainsAlcohol = p.ContainsAlcohol;

                var Checkbox = new ProductCheckboxOptions
                {
                    IsChecked = false,
                    Value = Product.Name,
                };
                //Checkbox.Value = Product.Name;

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
        [Authorize(Policy = "EmployeeOnly")]
        public async Task<ActionResult> CreatePackage(PackageViewModel Package)
        {
            var ThisEmployee = _EmployeeRepo.GetEmployeeByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (!_CanteenRepo.ServesHotMeals(ThisEmployee.CanteenLocation) && Package.Type.Equals(EnumMealType.HotMeal))
            {
                ModelState.AddModelError("", "Invalid package");
                return View(Package);
            }

            var Prod = _ProductRepo.GetAll().ToList();
            Package.Checkboxes = new List<ProductCheckboxOptions>();
            foreach (var p in Prod)
            {
                var Product = new Product();
                Product.Name = p.Name;
                Product.ImageUrl = p.ImageUrl;
                Product.ContainsAlcohol = p.ContainsAlcohol;

                var Checkbox = new ProductCheckboxOptions
                {
                    IsChecked = false,
                    Value = Product.Name,
                };

                if (Checkbox == null)
                {

                }
                else
                {
                    Package.Checkboxes.Add(Checkbox);
                }
            }

            if (ModelState.IsValid)
            {
                var ProductList = new List<Product>();
                var ProductDataList = _ProductRepo.GetAll().ToList();
                foreach (var ProductName in Package.Products)
                {
                    foreach (var product in ProductDataList)
                    {
                        if (ProductName.Equals(product.Name))
                        {
                            ProductList.Add(product);
                        }
                    }
                }

                var Employee = _EmployeeRepo.GetEmployeeByEmail(User.FindFirstValue(ClaimTypes.Email));
                var EmployeeCity = EnumCity.Breda;
                if (Employee.CanteenLocation == "Ld")
                {
                    EmployeeCity = EnumCity.Tilburg;
                }
                if (Employee.CanteenLocation == "Lc")
                {
                    EmployeeCity = EnumCity.DenBosch;
                }
                var NewPackage = new Package
                {
                    Name = Package.Name,
                    City = EmployeeCity,
                    ContainsAlcohol = Package.ContainsAlcohol,
                    Price = Package.Price,
                    Canteen = Package.Canteen,
                    CanteenLocation = Employee.CanteenLocation,
                    Products = ProductList,
                    PickUpTimeStart = Package.PickUpTimeStart,
                    PickUpTimeEnd = Package.PickUpTimeEnd,
                    Type = Package.Type,
                    ReservedBy = Package.ReservedBy,
                    StudentId = Package.StudentId
                };
                await _PackageRepo.AddPackage(NewPackage);

                return View("Index", _PackageRepo.GetUnReservedPackagesFilteredDateAsc());
            }
            ModelState.AddModelError("", "Invalid package");
            return View(Package);
        }

        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult UpdatePackage(int id)
        {
            var Prod = _ProductRepo.GetAll().ToList();
            var ThisPackage = _PackageRepo.GetPackageById(id);

            var ContainedProductNames = new List<string>();

            if (ThisPackage.Products != null && ThisPackage.Products.Count != 0)
            {
                foreach (var p in ThisPackage.Products)
                {
                    ContainedProductNames.Add(p.Name);
                }
            }

            var Pack = new PackageViewModel
            {
                Id = id,
                Name = ThisPackage.Name,
                City = ThisPackage.City,
                ContainsAlcohol = ThisPackage.ContainsAlcohol,
                Price = ThisPackage.Price,
                Canteen = ThisPackage.Canteen,
                CanteenLocation = ThisPackage.CanteenLocation,
                Products = { },
                PickUpTimeStart = ThisPackage.PickUpTimeStart,
                PickUpTimeEnd = ThisPackage.PickUpTimeEnd,
                Type = ThisPackage.Type,
                ReservedBy = ThisPackage.ReservedBy,
                StudentId = ThisPackage.StudentId,

            };
            Pack.Checkboxes = new List<ProductCheckboxOptions>();
            Pack.Products = new List<string>();
            foreach (var p in Prod)
            {
                var Product = new Product();
                Product.Name = p.Name;
                Product.ImageUrl = p.ImageUrl;
                Product.ContainsAlcohol = p.ContainsAlcohol;

                var check = false;

                if (ContainedProductNames.Contains(Product.Name))
                {
                    check = true;
                }

                var Checkbox = new ProductCheckboxOptions
                {
                    IsChecked = check,
                    Value = Product.Name,
                };

                if (Checkbox == null)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    Pack.Checkboxes.Add(Checkbox);
                }
            }

            return View("EditPackage", Pack);
        }

        [Authorize(Policy = "EmployeeOnly")]
        [HttpPost]
        public async Task<ActionResult> UpdatePackage(PackageViewModel Package)
        {
            var ThisEmployee = _EmployeeRepo.GetEmployeeByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (!_CanteenRepo.ServesHotMeals(ThisEmployee.CanteenLocation) && Package.Type.Equals(EnumMealType.HotMeal))
            {
                ModelState.AddModelError("", "Invalid package");
                return View(Package);
            }

            var Prod = _ProductRepo.GetAll().ToList();
            Package.Checkboxes = new List<ProductCheckboxOptions>();
            foreach (var p in Prod)
            {
                var Product = new Product();
                Product.Name = p.Name;
                Product.ImageUrl = p.ImageUrl;
                Product.ContainsAlcohol = p.ContainsAlcohol;

                var Checkbox = new ProductCheckboxOptions
                {
                    IsChecked = false,
                    Value = Product.Name,
                };
                //Checkbox.Value = Product.Name;

                if (Checkbox == null)
                {

                }
                else
                {
                    Package.Checkboxes.Add(Checkbox);
                }
            }

            if (ModelState.IsValid)
            {
                var ProductList = new List<Product>();
                var ProductDataList = _ProductRepo.GetAll().ToList();
                foreach (var ProductName in Package.Products)
                {
                    foreach (var product in ProductDataList)
                    {
                        if (ProductName.Equals(product.Name))
                        {
                            ProductList.Add(product);
                        }
                    }
                }

                var Employee = _EmployeeRepo.GetEmployeeByEmail(User.FindFirstValue(ClaimTypes.Email));
                var EmployeeCity = EnumCity.Breda;
                if (Employee.CanteenLocation == "Ld")
                {
                    EmployeeCity = EnumCity.Tilburg;
                }
                if (Employee.CanteenLocation == "Lc")
                {
                    EmployeeCity = EnumCity.DenBosch;
                }

                var NewPackage = new Package
                {
                    Id = Package.Id,
                    Name = Package.Name,
                    City = EmployeeCity,
                    ContainsAlcohol = Package.ContainsAlcohol,
                    Price = Package.Price,
                    Canteen = Package.Canteen,
                    CanteenLocation = Employee.CanteenLocation,
                    Products = ProductList,
                    PickUpTimeStart = Package.PickUpTimeStart,
                    PickUpTimeEnd = Package.PickUpTimeEnd,
                    Type = Package.Type,
                    ReservedBy = Package.ReservedBy,
                    StudentId = Package.StudentId
                };


                var CurrentPackage = _PackageRepo.UpdatePackageById(NewPackage);

                return View("AdminPackageDetails", CurrentPackage);
            }
            ModelState.AddModelError("", "Invalid package");
            return View("EditPackage", Package);
        }
    }
}
