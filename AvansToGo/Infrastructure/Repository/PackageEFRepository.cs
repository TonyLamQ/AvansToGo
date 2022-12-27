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

        public List<Package> GetReservedPackagesBy(Student Student)
        {
            return _context.Packages.Select(p => p).Where(p => p.ReservedBy == Student).ToList();
        }

        public List<Package> GetUnReservedPackages()
        {
            return _context.Packages.Select(p=> p).Where(p => p.ReservedBy==null).ToList(); 
        }
    }
}
