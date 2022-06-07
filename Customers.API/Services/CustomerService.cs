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

        public Customer UpdateCustomer(Customer updatedCustomer)
        {
            if (updatedCustomer is not null)
            {
                Customer customer = _customers.FirstOrDefault(x => x.Id == updatedCustomer.Id);
                customer = updatedCustomer;
                return updatedCustomer;
            }
            else
                return null;
        }
        public void DeleteCustomerById(Guid customerId)
        {
            Customer customer = _customers.FirstOrDefault(x => x.Id == customerId);
            if (customer is not null)
                _customers.Remove(customer);
        }
        public double MakePurshace(Guid customerId, Purshace purshace)
        {
            Customer customer = _customers.FirstOrDefault(x => x.Id == customerId);

            if (customer is not null)
            {
                if (customer.Purshaces is null)
                    customer.Purshaces = new List<Purshace>();

                customer.Purshaces.Add(purshace);

                double cost = Helpers.Helper.ReturnDiscountCost(customer, purshace);

                return cost;

            } else
                return 0;
        }
    }
}
