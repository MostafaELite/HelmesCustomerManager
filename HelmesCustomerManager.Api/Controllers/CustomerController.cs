using HelmesCustomerManager.Domain.Dtos;
using HelmesCustomerManager.Domain.Entities;
using HelmesCustomerManager.Domain.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HelmesCustomerManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerService customersService) : ControllerBase
{
    [Produces(typeof(IEnumerable<Customer>))]
    [HttpGet]
    public IActionResult GetCustomers()
    {
        var customers = customersService.GetCustomers();
        return Ok(customers);
    }

    [HttpGet("{customerId}")]
    public IActionResult GetCustomer(Guid customerId)
    {
        var customer = customersService.GetCustomers(new[] { customerId }).FirstOrDefault();
        return customer is null ? NotFound() : Ok(customer.Adapt<CustomerViewModel>());
    }

    [HttpPut("{customerId}")]
    public async Task<IActionResult> UpdateCustomerAsync(Guid customerId, CustomerViewModel updatedPayload)
    {
        await customersService.UpdateCustomer(customerId, updatedPayload);
        return Ok();
    }


    [HttpPost]
    public IActionResult AddCustomer(CustomerViewModel customerPayload)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdCustomer = customersService.AddCustomer(customerPayload);

        //TODO: adapt and return CustomerViewModel
        return Created($"/{createdCustomer.Id}", createdCustomer);
    }
}