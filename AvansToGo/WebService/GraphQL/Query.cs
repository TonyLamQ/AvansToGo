using Portal.Models;
using Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Services.IRepository;
using Core.Domain;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebService.GraphQL
{
    [Authorize]
    public class Query
    {
        private readonly IPackageRepo _packageRepo;
        private readonly IStudentRepo _studentRepo;
        private readonly IProductRepo _productRepo;
        public Query(IPackageRepo packageRepo, IStudentRepo studentRepo, IProductRepo productRepo)
        {
            _packageRepo = packageRepo;
            _studentRepo = studentRepo;
            _productRepo = productRepo;
        }

        public IQueryable<Package> UnreservedPackages => _packageRepo.GetAll();

        public List<Package> MyPackages(string email)
        {  
            var student = _studentRepo.GetStudentByEmail(email);
            return _packageRepo.GetReservedPackagesBy(student);
        }

        public Package PackageDetails(int id)
        {
            var result = _packageRepo.GetPackageById(id);
            return result;
        }
        public IQueryable<Product> AllProducts()
        {
            var result = _productRepo.GetAll();
            return result;
        }

    }
}
