﻿using Core.Domain;
using Core.Domain.Services.IRepository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using System.Globalization;
using System.Security.Claims;

namespace Portal.Controllers
{
    public class PackageController : Controller
    {
        private readonly ILogger<PackageController> _logger;
        private readonly IPackageRepo _PackageRepo;
        private readonly IStudentRepo _StudentRepo;
        private readonly IProductRepo _ProductRepo;
        private readonly IEmployeeRepo _EmployeeRepo;


        public PackageController(
            ILogger<PackageController> logger,
            IPackageRepo PackageRepo,
             IStudentRepo StudentRepo,
             IProductRepo ProductRepo,
             IEmployeeRepo employeeRepo
            )
        {
            _logger = logger;
            _PackageRepo = PackageRepo;
            _StudentRepo = StudentRepo;
            _ProductRepo = ProductRepo;
            _EmployeeRepo = employeeRepo;
        }

        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult Index()
        {
            return View(_PackageRepo.GetUnReservedPackagesFilteredDateAsc());
        }

        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult Details(int id)
        {
            return View(_PackageRepo.GetPackageById(id));
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
                    PickUpTimeStart = DateTime.Now,
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

            if(ThisPackage.Products != null && ThisPackage.Products.Count != 0)
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
            if(ModelState.IsValid)
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
                    Id= Package.Id,
                    Name = Package.Name,
                    City = EmployeeCity,
                    ContainsAlcohol = Package.ContainsAlcohol,
                    Price = Package.Price,
                    Canteen = Package.Canteen,
                    CanteenLocation = Employee.CanteenLocation,
                    Products = ProductList,
                    PickUpTimeStart = DateTime.Now,
                    PickUpTimeEnd = Package.PickUpTimeEnd,
                    Type = Package.Type,
                    ReservedBy = Package.ReservedBy,
                    StudentId = Package.StudentId
                };
                
              
                var CurrentPackage = _PackageRepo.UpdatePackageById(NewPackage);

                return View("Details", CurrentPackage);
            }
            ModelState.AddModelError("", "Invalid package");
            return View("Index", _PackageRepo.GetUnReservedPackages());
        }
    }
}
