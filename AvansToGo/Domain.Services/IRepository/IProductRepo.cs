﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services.IRepository
{
    public interface IProductRepo
    {
        //Create

        //Read
        IQueryable<Product> GetAll();
        List<string> GetAllNames();
        //Update

        //Delete
    }
}
