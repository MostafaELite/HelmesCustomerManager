using HelmesCustomerManager.Domain.Dtos;
using HelmesCustomerManager.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelmesCustomerManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerService customersService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetCustomers()
    {
        //In many cases, we may want to add a viewModel here
        var customers = customersService.GetCustomers();
        return Ok(customers);
    }


    [HttpPost]
    public IActionResult AddCustomer(CreateCustomerModel customerPayload)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        customersService.AddCustomer(customerPayload);

        return Ok();
    }
}