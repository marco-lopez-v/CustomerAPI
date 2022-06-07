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
    public async Task<IActionResult> CreateCustomer(Customer customer)
    {
        Customer createdCustomer = await _customerService.CreateCustomer(customer);
        if (createdCustomer != null)
            return Ok(createdCustomer);
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getCustomer")]
    public async Task<IActionResult> GetCustomer()
    {
        List<Customer> customers = await _customerService.GetCustomers();

        if (customers.Any())
            return Ok(customers);

        return NotFound();
    }

    [HttpPut]
    [Route("updateCustomer")]
    public async Task<IActionResult> UpdateCustomer(Customer customer)
    {
        Customer updatedCustomer = await _customerService.UpdateCustomer(customer);

        if (updatedCustomer is not null)
            return Ok(updatedCustomer);

        return NotFound();
    }

    [HttpDelete]
    [Route("deleteCustomer")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        Customer deletedCustomer = await _customerService.DeleteCustomerById(id);

        if (deletedCustomer != null)
            return Ok(deletedCustomer);
        else
            return NotFound();
    }

    [HttpPost]
    [Route("makePurshace")]
    public async Task<IActionResult> MakePurshace(Guid id, Purshace purshace)
    {
        double cost = await _customerService.MakePurshace(id, purshace);
        return Ok(cost);
    }
}