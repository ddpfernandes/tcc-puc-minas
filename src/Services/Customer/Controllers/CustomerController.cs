using Customer.Application.Commands;
using Customer.Application.Queries;
using Customer.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers;

// [Authorize]
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IMediator _mediator;
    private readonly ICustomerQueries _customerQueries;

    public CustomerController(
        ILogger<CustomerController> logger,
        IMediator mediator,
        ICustomerQueries customerQueries)
    {
        _logger = logger;
        _mediator = mediator;
        _customerQueries = customerQueries;
    }

    /// <summary>
    /// Create a new customer.
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    /// <summary>
    /// Get all customers.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerQueries.GetAllCustomer();
        return Ok(customers);
    }

    /// <summary>
    /// Get customer by Id.
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var customer = await _customerQueries.GetCustomer(id);
        return Ok(customer);
    }

    /// <summary>
    /// Update user data.
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CustomerUpdateViewModel dto)
    {
        return Ok();
    }

    /// <summary>
    /// Delete user.
    /// </summary>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok();
    }
}
