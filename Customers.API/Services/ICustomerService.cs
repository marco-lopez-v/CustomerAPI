using Customers.API.Models;

namespace Customers.API.Services
{
    public interface ICustomerService
    {
        void CreateCustomer(Customer customer);

        Task<List<Customer>> GetCustomers();

        Customer UpdateCustomer(Customer customer);

        void DeleteCustomerById(Guid id);

        double MakePurshace(Guid Id, Purshace purshace);
    }
}