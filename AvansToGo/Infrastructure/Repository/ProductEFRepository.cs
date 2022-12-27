using Core.Domain;
using Core.Domain.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductEFRepository : IProductRepo
    {
        private readonly AvansToGoContext _context;
        public ProductEFRepository(AvansToGoContext context)
        {
            _context = context;
        }
        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }
    }
}
