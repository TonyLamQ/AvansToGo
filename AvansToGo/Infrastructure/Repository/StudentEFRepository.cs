using Core.Domain;
using Core.Domain.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class StudentEFRepository : IStudentRepo
    {
        private readonly AvansToGoContext _context;
        public StudentEFRepository(AvansToGoContext context)
        {
            _context = context;
        }
        public IQueryable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student GetStudentByEmail(string Email)
        {
            return GetAll().Select(S => S).Where(S => S.Email == Email).First();
        }
    }
}
