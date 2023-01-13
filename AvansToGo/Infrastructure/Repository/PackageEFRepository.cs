using Core.Domain;
using Core.Domain.Services.IRepository;

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
            return _context.Packages;
        }

        public Package GetPackageById(int id)
        {
            var package = _context.Packages.Where(p => p.Id == id).First()!;
            return package;
        }

        public List<Package> GetReservedPackagesBy(Student Student)
        {
            return _context.Packages.Where(p => p.ReservedBy == Student).ToList();
        }

        public List<Package> GetUnReservedPackages()
        {
            return _context.Packages.Select(p=> p).Where(p => p.ReservedBy==null).ToList(); 
        }

        public List<Package> GetUnReservedPackagesFilteredDateAsc()
        {
            return GetUnReservedPackages().OrderBy(p => p.PickUpTimeStart).ToList();
        }
    }
}
