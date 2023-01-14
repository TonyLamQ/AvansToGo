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
        public async Task AddPackage(Package package)
        {
            _context.Packages.Add(package);            
            await _context.SaveChangesAsync();
        }
        //Read
        public IQueryable<Package> GetAll()
        {
            return _context.Packages.Include(x => x.Products);
        }

        public Package GetPackageById(int id)
        {
            var package = _context.Packages.Include(x=>x.Products).Where(p => p.Id == id).First()!;
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

            CurrentPackage.Name = NewPackage.Name;
            CurrentPackage.City = NewPackage.City;
            CurrentPackage.ContainsAlcohol = NewPackage.ContainsAlcohol;
            CurrentPackage.Price = NewPackage.Price;
            CurrentPackage.Canteen = NewPackage.Canteen;
            CurrentPackage.CanteenLocation = NewPackage.CanteenLocation;
            CurrentPackage.Products = NewPackage.Products.ToList();
            CurrentPackage.PickUpTimeStart = NewPackage.PickUpTimeStart;
            CurrentPackage.PickUpTimeEnd = NewPackage.PickUpTimeEnd;
            CurrentPackage.Type = NewPackage.Type;
            CurrentPackage.ReservedBy = NewPackage.ReservedBy;
            CurrentPackage.StudentId = NewPackage.StudentId;

            _context.SaveChanges();

            return CurrentPackage;
        }

        //Delete
        public void DeletePackageById(int id)
        {
            var Package = _context.Packages.Find(id);
            _context.Packages.Remove(Package);
            _context.SaveChanges();
        }
     
    }
}
