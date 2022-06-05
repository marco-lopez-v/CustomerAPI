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

    [HttpPost(Name = "createCustomer")]
    public async Task<IActionResult> CreateCustomer(Customer customer)
    {
        _customerService.CreateCustomer(customer);
        return Ok();
    }
    [HttpGet(Name = "getCustomer")]
    public async Task<IActionResult> GetCustomer()
    {
        var customers = await _customerService.GetCustomers();

        if (customers.Any())
            return Ok(customers);

        return NotFound();
    }
    [HttpPut(Name = "updateCustomer")]
    public async Task<IActionResult> UpdateCustomer(Customer customer)
    {
        var updatedCustomer = _customerService.UpdateCustomer(customer);

        if (updatedCustomer is not null)
            return Ok(updatedCustomer);

        return NotFound();
    }
    [HttpDelete(Name = "deleteCustomer")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        _customerService.DeleteCustomerById(id);
        return Ok();
    }
}
