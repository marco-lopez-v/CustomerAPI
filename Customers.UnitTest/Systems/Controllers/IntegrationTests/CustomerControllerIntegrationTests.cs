using Customers.API.Controllers;
using Customers.API.Models;
using Customers.API.Services;
using Customers.UnitTest.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
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

    [Fact]
    public async Task Create_ValidCustomer_Returns200()
    {
        // Arrange
        var mockCustomerService = new Mock<ICustomerService>();

        mockCustomerService
            .Setup(service => service.CreateCustomer(It.IsAny<Customer>()))
            .ReturnsAsync(CustomersFixture.GetTestCustomer());

        var sut = new CustomersController(mockCustomerService.Object);

        // Act
        var result = await sut.CreateCustomer(CustomersFixture.GetTestCustomer());

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<Customer>();
    }

    [Fact]
    public async Task Create_InvalidCustomer_Returns400()
    {
        // Arrange
        var mockCustomerService = new Mock<ICustomerService>();

        mockCustomerService
            .Setup(service => service.CreateCustomer(It.IsAny<Customer>()))
            .ReturnsAsync(null as Customer);

        var sut = new CustomersController(mockCustomerService.Object);

        // Act
        var result = await sut.CreateCustomer(CustomersFixture.GetTestCustomer());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task Update_ValidCustomer_Returns200()
    {
        // Arrange
        var mockCustomerService = new Mock<ICustomerService>();

        mockCustomerService
            .Setup(service => service.UpdateCustomer(It.IsAny<Customer>()))
            .ReturnsAsync(CustomersFixture.GetTestCustomer());

        var sut = new CustomersController(mockCustomerService.Object);

        // Act
        var result = await sut.UpdateCustomer(CustomersFixture.GetTestCustomer());

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<Customer>();
    }

    [Fact]
    public async Task Update_InvalidCustomer_Returns400()
    {
        // Arrange
        var mockCustomerService = new Mock<ICustomerService>();

        mockCustomerService
            .Setup(service => service.UpdateCustomer(It.IsAny<Customer>()))
            .ReturnsAsync(null as Customer);

        var sut = new CustomersController(mockCustomerService.Object);

        // Act
        var result = await sut.UpdateCustomer(CustomersFixture.GetTestCustomer());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task Delete_ValidCustomer_Returns200()
    {
        // Arrange
        var mockCustomerService = new Mock<ICustomerService>();

        mockCustomerService
            .Setup(service => service.DeleteCustomerById(It.IsAny<Guid>()))
            .ReturnsAsync(CustomersFixture.GetTestCustomer());

        var sut = new CustomersController(mockCustomerService.Object);

        // Act
        var result = await sut.DeleteCustomer(CustomersFixture.GetTestCustomer().Id);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<Customer>();
    }

    [Fact]
    public async Task Delete_InvalidCustomer_Returns400()
    {
        // Arrange
        var mockCustomerService = new Mock<ICustomerService>();

        mockCustomerService
            .Setup(service => service.DeleteCustomerById(It.IsAny<Guid>()))
            .ReturnsAsync(null as Customer);

        var sut = new CustomersController(mockCustomerService.Object);

        // Act
        var result = await sut.DeleteCustomer(CustomersFixture.GetTestCustomer().Id);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task Make_ValidCustomerAndPurshace_Returns200()
    {
        // Arrange
        var mockCustomerService = new Mock<ICustomerService>();

        mockCustomerService
            .Setup(service => service.MakePurshace(It.IsAny<Guid>(), It.IsAny<Purshace>()))
            .ReturnsAsync(100);

        var sut = new CustomersController(mockCustomerService.Object);

        // Act
        var result = await sut.MakePurshace(CustomersFixture.GetTestCustomer().Id, CustomersFixture.GetTestPurshace());

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<double>();
    }

    [Fact]
    public async Task Make_InvalidCustomerAndPurshace_Returns400()
    {
        // Arrange
        var mockCustomerService = new Mock<ICustomerService>();

        mockCustomerService
            .Setup(service => service.MakePurshace(It.IsAny<Guid>(), It.IsAny<Purshace>()))
            .ReturnsAsync(0);

        var sut = new CustomersController(mockCustomerService.Object);

        // Act
        var result = await sut.MakePurshace(CustomersFixture.GetTestCustomer().Id, CustomersFixture.GetTestPurshace());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}