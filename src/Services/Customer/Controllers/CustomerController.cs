using Cliente.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ILogger<ClienteController> _logger;

    public ClienteController(ILogger<ClienteController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Create a new customer.
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create()
    {
        return Ok();
    }

    /// <summary>
    /// Get all customers.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    /// <summary>
    /// Get customer by Id.
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [HttpPost]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok();
    }

    /// <summary>
    /// Update user data.
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}")]
    [HttpPost]
    public async Task<IActionResult> Update(Guid id, [FromBody] CustomerUpdateViewModel dto)
    {
        return Ok();
    }
    
    /// <summary>
    /// Delete user.
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}")]
    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok();
    }
}
