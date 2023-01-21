using Portal.Models;
using Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Services.IRepository;
using Core.Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebService.GraphQL
{
    [Authorize]
    public class Mutation
    {
        private readonly IPackageRepo _packageRepo;

        public Mutation(IPackageRepo packageRepo)
        {
            _packageRepo = packageRepo;
        }

        public async Task<Package> Create(Package package) => await _packageRepo.AddPackage(package);
        public bool Delete(Package package) => _packageRepo.DeletePackageById(package.Id);
    }
}
