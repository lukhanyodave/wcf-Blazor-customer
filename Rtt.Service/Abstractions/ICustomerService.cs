
using Rtt.Service.Dtos;
using ServiceReference1;

namespace Rtt.Service.Abstractions
{
    public interface ICustomerService
    {
        Task CreateUser(CustomerDto customer);
        Task UpdateUser(CustomerDto customer);
        Task<CustomerDto> GetById(Guid id);
        Task<List<CustomerContract>> GetAll();
    }
}
