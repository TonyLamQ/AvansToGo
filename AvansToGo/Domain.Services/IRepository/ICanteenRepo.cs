using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services.IRepository
{
    public interface ICanteenRepo
    {
        //Create

        //Read
        IQueryable<Canteen> GetAll();
        bool ServesHotMeals(string Location);
        //Update

        //Delete
    }
}
