using Core.Domain.Services.IRepository;
using Core.Domain.Services.IServices;

namespace Core.Domain.Services.Services
{
    public class AvansToGoService : IAvansToGoService
    {
        private readonly IAvansToGoService _service;
        public AvansToGoService(IPackageRepo packageRepo)
        {

        }
    }
}
