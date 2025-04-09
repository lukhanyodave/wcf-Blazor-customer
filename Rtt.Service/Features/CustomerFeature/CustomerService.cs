using Rtt.Service.Abstractions;
using Rtt.Service.Dtos;
using ServiceReference1;
using System.Collections.Generic;
namespace Rtt.Service.Features.CustomerFeature
{
    public class CustomerService : ICustomerService
    {
        ServiceReference1.Service1Client service1Client = new ServiceReference1.Service1Client();
        public async Task CreateUser(CustomerDto customer)
        {
            await service1Client.AddCustomerAsync(
                new CustomerContract()
                {
                    Id = Guid.NewGuid(),
                    Name = customer.Name,
                    LastName = customer.LastName,
                    Gender = customer.Gender,
                    PostalAddress = customer.PostalAddress,
                    ResidentialAddress = customer.ResidentialAddress,
                    WorkAddress = customer.WorkAddress,
                    Cell = customer.Cell,
                    WorkNumber = customer.WorkNumber
                }
                );
        }

        public async Task UpdateUser(CustomerDto customer)
        {
            await service1Client.UpdateCustomerAsync(
                new CustomerContract()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    LastName = customer.LastName,
                    Gender = customer.Gender,
                    PostalAddress = customer.PostalAddress,
                    ResidentialAddress = customer.ResidentialAddress,
                    WorkAddress = customer.WorkAddress,
                    Cell = customer.Cell,
                    WorkNumber = customer.WorkNumber
                }
                );
        }

        public async Task<List<CustomerContract>> GetAll()
        {
            List<CustomerContract> list = new();
            var results = await service1Client.GetAllAsync();
            return results.ToList();
        }

        public async Task<CustomerDto> GetById(Guid id)
        {
            var customer = await service1Client.GetByIdAsync(id);

            return new CustomerDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                LastName = customer.LastName,
                Gender = customer.Gender,
                PostalAddress = customer.PostalAddress,
                ResidentialAddress = customer.ResidentialAddress,
                WorkAddress = customer.WorkAddress,
                Cell = customer.Cell,
                WorkNumber = customer.WorkNumber
            };
        }
    }
}
