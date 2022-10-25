﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services.IRepository
{
    public interface IPackageRepo
    {
        //Create

        //Read
        IQueryable<Package> GetAll();
        List<Package> GetReservedPackagesBy();
        List<Package> GetUnReservedPackages();
        //Update

        //Delete
    }
}
