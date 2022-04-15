using Acesso.Application.Commands;
using Acesso.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Acesso.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("auth")]
    public async Task<IActionResult> Login()
    {
        return Ok();
    }

    /// <summary>
    /// Create a new user.
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        return Ok();
    }

    /// <summary>
    /// Get all users.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    /// <summary>
    /// Get user by Id.
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok();
    }

    /// <summary>
    /// Update user data.
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateViewModel dto)
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