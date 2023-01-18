using Core.Domain;
using Core.Domain.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CanteenEFRepository : ICanteenRepo
    {
        private readonly AvansToGoContext _context;
        public CanteenEFRepository(AvansToGoContext context)
        {
            _context = context;
        }
        public IQueryable<Canteen> GetAll()
        {
            return _context.Canteens;
        }

        public bool ServesHotMeals(string Location)
        {
            return GetAll().Select(p => p).Where(p => p.Location == Location).First().ServesHotMeals == true;
        }
    }
}
