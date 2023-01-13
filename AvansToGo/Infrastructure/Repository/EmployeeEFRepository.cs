using Core.Domain.Services.IRepository;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EmployeeEFRepository : IEmployeeRepo
    {
        private readonly AvansToGoContext _context;
        public EmployeeEFRepository(AvansToGoContext context)
        {
            _context = context;
        }
        public IQueryable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetEmployeeByEmail(string Email)
        {
            return GetAll().Select(S => S).Where(S => S.Email == Email).First();
        }
    }
}
