using Acesso.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Acesso.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AcessoController : ControllerBase
{
    private readonly ILogger<AcessoController> _logger;

    public AcessoController(ILogger<AcessoController> logger)
    {
        _logger = logger;
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
    public async Task<IActionResult> Create()
    {
        return Ok();
    }

    /// <summary>
    /// Get all users.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    /// <summary>
    /// Get user by Id.
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
    public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateViewModel dto)
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