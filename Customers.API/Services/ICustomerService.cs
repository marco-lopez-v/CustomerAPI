using Customers.API.Models;

namespace Customers.API.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(Customer customer);

        Task<List<Customer>> GetCustomers();

        Task<Customer> UpdateCustomer(Customer customer);

        Task<Customer> DeleteCustomerById(Guid id);

        Task<double> MakePurshace(Guid Id, Purshace purshace);
    }
}