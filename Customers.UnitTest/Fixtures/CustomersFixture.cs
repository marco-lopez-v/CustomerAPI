using Customers.API.Models;
using System;
using System.Collections.Generic;

namespace Customers.UnitTest.Fixtures
{
    public static class CustomersFixture
    {
        public static List<Customer> GetTestCustomers() =>
            new()
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Marco",
                    Purshaces = new List<Purshace>() { new Purshace() { Id = Guid.NewGuid(), Amount = 100 } },
                }
            };

        public static Customer GetTestCustomer() => new Customer { Id = Guid.NewGuid(), Name = "Jose", Purshaces = null };

        public static Purshace GetTestPurshace() => new Purshace { Id = Guid.NewGuid(), Amount = 100 };
    }
}