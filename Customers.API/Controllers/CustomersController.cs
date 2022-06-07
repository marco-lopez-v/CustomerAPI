using Customers.API.Models;
using Customers.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    [Route("createCustomer")]
    public IActionResult CreateCustomer(Customer customer)
    {
        _customerService.CreateCustomer(customer);
        return Ok();
    }
    [HttpGet]
    [Route("getCustomer")]
    public async Task<IActionResult> GetCustomer()
    {
        var customers = await _customerService.GetCustomers();

        if (customers.Any())
            return Ok(customers);

        return NotFound();
    }
    [HttpPut]
    [Route("updateCustomer")]
    public IActionResult UpdateCustomer(Customer customer)
    {
        var updatedCustomer = _customerService.UpdateCustomer(customer);

        if (updatedCustomer is not null)
            return Ok(updatedCustomer);

        return NotFound();
    }
    [HttpDelete]
    [Route("deleteCustomer")]
    public IActionResult DeleteCustomer(Guid id)
    {
        _customerService.DeleteCustomerById(id);
        return Ok();
    }
    [HttpPost]
    [Route("makePurshace")]
    public IActionResult MakePurshace(Guid id, Purshace purshace)
    {
        double cost = _customerService.MakePurshace(id, purshace);
        return Ok(cost);
    }
}
