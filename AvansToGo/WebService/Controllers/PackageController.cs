using Core.Domain.Services.IRepository;
using Core.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Portal.Models;

namespace WebApi.Controller
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
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

        [HttpGet]
        public ICollection<Package> GetUnreserved()
        {
            return _PackageRepo.GetUnReservedPackagesFilteredDateAsc();
        }

        [HttpGet("MyPackages")]
        public IActionResult MyPackages()
        {
            if (User == null)
            {
                return NotFound("Could not find user.");
            } else
            {
                var Student = _StudentRepo.GetStudentByEmail(User.FindFirstValue(ClaimTypes.Email));
                return Ok(_PackageRepo.GetReservedPackagesBy(Student));
            }
            
        }
        [HttpGet("Details/{id}")]
        public IActionResult PackageDetails(int id)
        {
            var result = _PackageRepo.GetPackageById(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("Reserve/{id}")]
        public IActionResult ReservePackage(int id)
        {
            var Student = _StudentRepo.GetStudentByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (Student != null)
            {
                var succeeded = _PackageRepo.AddReservedById(Student.StudentId, id);
                if (!succeeded)
                {
                    return NotFound();
                } else
                {
                    return Ok(new {Success=true, Message="You reserved package "+id});
                }
            } else
            {
                return NotFound();
            }
        }

        [HttpPost("Unreserve/{id}")]
        public IActionResult UnreservePackage(int id)
        {
            var Student = _StudentRepo.GetStudentByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (Student != null)
            {
                _PackageRepo.AddUnreservedById(Student.StudentId, id);
                return Ok(new {Success=true, Message="Unreserved package with id "+id});
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreatePackage([FromBody]PackageModel Package)
        {
            if (User.HasClaim(c => c.Type == "Student"))
            {
                return BadRequest("You are not an employee.");
            }

            var ThisEmployee = _EmployeeRepo.GetEmployeeByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (!_CanteenRepo.ServesHotMeals(ThisEmployee.CanteenLocation) && Package.Type.Equals(EnumMealType.HotMeal))
            {
                ModelState.AddModelError("", "Invalid package");
                return BadRequest(" Canteen doesn't serve HotMeals");
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
                var EmployeeCity = EnumCity.Breda;
                if (ThisEmployee.CanteenLocation == "Ld")
                {
                    EmployeeCity = EnumCity.Tilburg;
                }
                if (ThisEmployee.CanteenLocation == "Lc")
                {
                    EmployeeCity = EnumCity.DenBosch;
                }
                var NewPackage = new Package
                {
                    Name = Package.Name,
                    ContainsAlcohol = Package.ContainsAlcohol,
                    Price = Package.Price,
                    CanteenLocation = ThisEmployee.CanteenLocation,
                    Products = ProductList,
                    PickUpTimeStart = Package.PickUpTimeStart,
                    PickUpTimeEnd = Package.PickUpTimeEnd,
                    Type = Package.Type
                };
                await _PackageRepo.AddPackage(NewPackage);

                return Ok(new { Success = true, Message = "Added Package " });
            }
            ModelState.AddModelError("", "Invalid package");
            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdatePackage(int id, [FromBody]PackageViewModel Package)
        {
                var ThisEmployee = _EmployeeRepo.GetEmployeeByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (!_CanteenRepo.ServesHotMeals(ThisEmployee.CanteenLocation) && Package.Type.Equals(EnumMealType.HotMeal))
            {
                ModelState.AddModelError("", "Invalid package");
                return BadRequest(" Canteen doesn't serve HotMeals");
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
                    Id = id,
                    Name = Package.Name,
                    ContainsAlcohol = Package.ContainsAlcohol,
                    City = EmployeeCity,
                    Price = Package.Price,
                    CanteenLocation = Employee.CanteenLocation,
                    Products = ProductList,
                    PickUpTimeStart = Package.PickUpTimeStart,
                    PickUpTimeEnd = Package.PickUpTimeEnd,
                    Type = Package.Type
                };


                _PackageRepo.UpdatePackageById(NewPackage);

                return Ok(new { Success = true, Message = "Updated Package "+id });
            }
            return BadRequest("Invalid package");
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeletePackage(int id)
        {
            _PackageRepo.DeletePackageById(id);
            return Ok(new { Success = true, Message = "Deleted package " + id });
        }
    }
}