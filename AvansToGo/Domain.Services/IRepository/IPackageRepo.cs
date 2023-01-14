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
        public Task AddPackage(Package package);
        //Read
        IQueryable<Package> GetAll();
        List<Package> GetReservedPackagesBy(Student Student);
        List<Package> GetUnReservedPackages();
        List<Package> GetUnReservedPackagesFilteredDateAsc();

        Package GetPackageById(int id);
        //Update
        Package UpdatePackageById(Package NewPackage);
        //Delete
        void DeletePackageById(int id);
    }
}
