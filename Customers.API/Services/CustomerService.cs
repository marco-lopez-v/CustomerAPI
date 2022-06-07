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

        public Task<Customer> CreateCustomer(Customer customer)
        {
            if (customer != null)
            {
                Customer existingCustomer = _customers.FirstOrDefault(x => x.Id == customer.Id);

                if (existingCustomer is null)
                {
                    _customers.Add(customer);
                    return Task.Run(() => customer);
                }
                else
                    return Task.FromResult<Customer>(null);
            }
            else
                return Task.FromResult<Customer>(null);
        }

        public Task<List<Customer>> GetCustomers()
        {
            return Task.Run(() => _customers);
        }

        public Task<Customer> UpdateCustomer(Customer updatedCustomer)
        {
            if (updatedCustomer != null)
            {
                Customer customer = _customers.FirstOrDefault(x => x.Id == updatedCustomer.Id);
                customer = updatedCustomer;
                return Task.Run(() => updatedCustomer);
            }
            else
                return Task.FromResult<Customer>(null);
        }

        public Task<Customer> DeleteCustomerById(Guid customerId)
        {
            if (customerId != Guid.Empty)
            {
                Customer customer = _customers.FirstOrDefault(x => x.Id == customerId);

                _customers.Remove(customer);
                return Task.Run(() => customer);
            }
            else
                return Task.FromResult<Customer>(null);
        }

        public Task<double> MakePurshace(Guid customerId, Purshace purshace)
        {
            Customer customer = _customers.FirstOrDefault(x => x.Id == customerId);

            if (customer != null && purshace != null && purshace.Amount > 0)
            {
                if (customer.Purshaces is null)
                    customer.Purshaces = new List<Purshace>();

                customer.Purshaces.Add(purshace);

                double cost = Helpers.Helper.ReturnDiscountCost(customer, purshace);

                return Task.Run(() => cost);
            }
            else
                return Task.FromResult<double>(0);
        }
    }
}