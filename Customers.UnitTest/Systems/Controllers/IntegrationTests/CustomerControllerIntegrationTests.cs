using Customers.API.Controllers;
using Customers.API.Models;
using Customers.API.Services;
using Customers.UnitTest.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Customers.UnitTest;

public class CustomerControllerIntegrationTests
{
    [Fact]
    public async Task Get_OnSucess_ReturnsListOfCustumers()
    {
        // Arrange
        var mockCustomerService = new Mock<ICustomerService>();
        mockCustomerService
            .Setup(service => service.GetCustomers())
            .ReturnsAsync(CustomersFixture.GetTestCustomers());

        var sut = new CustomersController(mockCustomerService.Object);

        // Act
        var result = await sut.GetCustomer();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<Customer>>();
    }

    [Fact]
    public async Task Get_OnNoCustomersFound_Returns404()
    {
        // Arrange
        var mockCustomerService = new Mock<ICustomerService>();
        mockCustomerService
            .Setup(service => service.GetCustomers())
            .ReturnsAsync(new List<Customer>());

        var sut = new CustomersController(mockCustomerService.Object);

        // Act
        var result = await sut.GetCustomer();

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}