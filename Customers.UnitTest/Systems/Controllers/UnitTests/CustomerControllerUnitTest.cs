using Customers.API.Models;
using Customers.API.Services;
using Customers.UnitTest.Fixtures;
using System.Threading.Tasks;
using Xunit;

namespace Customers.UnitTest.Systems.Controllers.UnitTests;

public class CustomerControllerUnitTest
{
    [Fact]
    public async Task Create_ValidCustomer_Success()
    {
        // Arrange
        CustomerService customerService = new CustomerService(CustomersFixture.GetTestCustomers());

        // Act
        var sut = await customerService.CreateCustomer(CustomersFixture.GetTestCustomer());

        // Assert
        Assert.NotNull(sut);
    }

    [Fact]
    public async Task Create_NullCustomer_Fail()
    {
        // Arrange
        CustomerService customerService = new CustomerService(CustomersFixture.GetTestCustomers());

        // Act
        Customer sut = await customerService.CreateCustomer(null);

        // Assert
        Assert.True(sut is null);
    }

    [Fact]
    public async Task Update_ValidCustomer_Success()
    {
        // Arrange
        Customer customer = CustomersFixture.GetTestCustomer();
        CustomerService customerService = new CustomerService(CustomersFixture.GetTestCustomers());

        // Act
        Customer createdCustomer = await customerService.CreateCustomer(customer);
        string oldName = createdCustomer.Name;
        customer.Name = "updatedName";
        Customer sut = await customerService.UpdateCustomer(customer);

        // Assert
        Assert.NotEqual(oldName, sut.Name);
    }

    [Fact]
    public async Task Update_NullCustomer_Fail()
    {
        // Arrange
        CustomerService customerService = new CustomerService(CustomersFixture.GetTestCustomers());

        // Act
        Customer sut = await customerService.UpdateCustomer(null);

        // Assert
        Assert.True(sut is null);
    }

    [Fact]
    public async Task Delete_ValidCustomer_Success()
    {
        // Arrange
        Customer customer = CustomersFixture.GetTestCustomer();
        CustomerService customerService = new CustomerService(CustomersFixture.GetTestCustomers());

        // Act
        await customerService.CreateCustomer(customer);
        Customer sut = await customerService.DeleteCustomerById(customer.Id);

        // Assert
        Assert.NotNull(sut);
    }

    [Fact]
    public async Task Delete_NullCustomer_Fail()
    {
        // Arrange
        CustomerService customerService = new CustomerService(CustomersFixture.GetTestCustomers());

        // Act
        Customer sut = await customerService.DeleteCustomerById(System.Guid.Empty);

        // Assert
        Assert.True(sut is null);
    }

    [Fact]
    public async Task MakePurshace_ValidCustomerAndPurshace_Success()
    {
        // Arrange
        CustomerService customerService = new CustomerService(CustomersFixture.GetTestCustomers());

        // Act
        Customer createdCustomer = await customerService.CreateCustomer(CustomersFixture.GetTestCustomer());

        double sut = await customerService.MakePurshace(createdCustomer.Id, CustomersFixture.GetTestPurshace());

        // Assert
        Assert.Equal(100, sut);
    }

    [Fact]
    public async Task MakePurshace_ValidCustomerAndNullPurshace_Error()
    {
        // Arrange
        CustomerService customerService = new CustomerService(CustomersFixture.GetTestCustomers());

        // Act
        Customer createdCustomer = await customerService.CreateCustomer(CustomersFixture.GetTestCustomer());

        double sut = await customerService.MakePurshace(createdCustomer.Id, null);

        // Assert
        Assert.True(sut is 0);
    }

    [Fact]
    public async Task MakePurshace_ValidCustomerAndZeroAmountPurshace_Error()
    {
        // Arrange
        CustomerService customerService = new CustomerService(CustomersFixture.GetTestCustomers());
        Purshace purshace = CustomersFixture.GetTestPurshace();
        // Act
        Customer createdCustomer = await customerService.CreateCustomer(CustomersFixture.GetTestCustomer());
        purshace.Amount = 0;

        double sut = await customerService.MakePurshace(createdCustomer.Id, purshace);

        // Assert
        Assert.True(sut is 0);
    }
}