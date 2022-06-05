using Customers.API.Models;

namespace Customers.API.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customers;

        public CustomerService(List<Customer> customers)
        {
            _customers = customers;
        }
        public void CreateCustomer(Customer customer)
        {
            if (customer is not null)
                _customers.Add(customer);
        }
        public Task<List<Customer>> GetCustomers()
        {
            return Task.Run(() => _customers);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            if (customer is not null)
            {
                Customer oldCustomer = _customers.FirstOrDefault(x => x.Id == customer.Id);
                oldCustomer = customer;
                return customer;
            }
            else
                return null;
        }
        public void DeleteCustomerById(Guid id)
        {
            Customer customer = _customers.FirstOrDefault(x => x.Id == id);
            _customers.Remove(customer);
        }
    }
}
