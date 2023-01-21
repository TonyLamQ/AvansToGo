using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services.IRepository
{
    public interface IPackageRepo
    {
        //Create
        public Task<Package> AddPackage(Package package);
        //Read
        IQueryable<Package> GetAll();
        List<Package> GetReservedPackagesBy(Student Student);
        List<Package> GetUnReservedPackages();
        List<Package> GetUnReservedPackagesFilteredDateAsc();
        Package GetPackageById(int id);
        //Update
        Package UpdatePackageById(Package NewPackage);
        bool AddReservedById(int UserId, int PackageId);

        void AddUnreservedById(int UserId, int PackageId);
        //Delete
        bool DeletePackageById(int id);
    }
}
