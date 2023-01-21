using Core.Domain;
using Core.Domain.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace Infrastructure.Repository
{
    public class PackageEFRepository : IPackageRepo
    {
        private readonly AvansToGoContext _context;
        public PackageEFRepository(AvansToGoContext context)
        {
            _context = context;
        }
        //Create
        public async Task<Package> AddPackage(Package package)
        {
            _context.Packages.Add(package);            
            await _context.SaveChangesAsync();
            return package;
        }
        //Read
        public IQueryable<Package> GetAll()
        {
            return _context.Packages.Include(x => x.Products);
        }

        public Package GetPackageById(int id)
        {   
            var package = _context.Packages.Include(x=>x.Products).Where(p => p.Id == id).FirstOrDefault();
            if (package == null)
            {
                return null;
            }
            return package;
        }

        public List<Package> GetReservedPackagesBy(Student Student)
        {
            return _context.Packages.Include(x => x.Products).Where(p => p.ReservedBy == Student).ToList();
        }

        public List<Package> GetUnReservedPackages()
        {
            return _context.Packages.Include(x => x.Products).Select(p=> p).Where(p => p.ReservedBy==null).ToList(); 
        }

        public List<Package> GetUnReservedPackagesFilteredDateAsc()
        {
            return GetUnReservedPackages().OrderBy(p => p.PickUpTimeStart).ToList();
        }

        //Update
        public Package UpdatePackageById(Package NewPackage)
        {
            var CurrentPackage = _context.Packages.Include(x => x.Products).Where(x=> x.Id==NewPackage.Id).First();

            CurrentPackage.Name = NewPackage.Name ?? CurrentPackage.Name;
            CurrentPackage.City = NewPackage.City;
            CurrentPackage.ContainsAlcohol = NewPackage.ContainsAlcohol;
            CurrentPackage.Price = NewPackage.Price ?? CurrentPackage.Price;
            CurrentPackage.Canteen = NewPackage.Canteen?? CurrentPackage.Canteen;
            CurrentPackage.CanteenLocation = NewPackage.CanteenLocation ?? CurrentPackage.CanteenLocation;
            CurrentPackage.Products = NewPackage.Products.ToList()?? CurrentPackage.Products;
            CurrentPackage.PickUpTimeStart = NewPackage.PickUpTimeStart?? CurrentPackage.PickUpTimeStart;
            CurrentPackage.PickUpTimeEnd = NewPackage.PickUpTimeEnd?? CurrentPackage.PickUpTimeEnd;
            CurrentPackage.Type = NewPackage.Type;
            CurrentPackage.ReservedBy = NewPackage.ReservedBy?? CurrentPackage.ReservedBy;
            CurrentPackage.StudentId = NewPackage.StudentId ?? CurrentPackage.StudentId;

            _context.SaveChanges();

            return CurrentPackage;
        }

        public bool AddReservedById(int UserId, int PackageId)
        {
            var Bool = true;
            var Package = _context.Packages.Find(PackageId);
            var student = _context.Students.Find(UserId);
            if(Package!.ReservedBy == null)
            {
                if (Package.ContainsAlcohol)
                {
                    var age = Package.PickUpTimeStart.Value.Year - student.BirthDate.Year;
                    if (age >=18)
                    {
                        Package!.ReservedBy = student;
                    } else
                    {
                        Bool = false;
                    }
                } else
                {
                    Package!.ReservedBy = student;
                }

            } else
            {
                Bool = false;
            }
           
            _context.SaveChanges();
            return Bool;

        }

        public void AddUnreservedById(int UserId, int PackageId)
        {
            var Package = _context.Packages.Find(PackageId);

            Package!.ReservedBy = null;

            _context.SaveChanges();
        }

        //Delete
        public bool DeletePackageById(int id)
        {
            var Package = _context.Packages.Find(id);
            if(Package == null)
            {
                return false;
            }
            else
            {
                _context.Packages.Remove(Package!);
                _context.SaveChanges();
                return true;
            }

        }
     
    }
}
