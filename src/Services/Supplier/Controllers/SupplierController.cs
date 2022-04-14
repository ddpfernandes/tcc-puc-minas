using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supplier.ViewModels;

namespace Fornecedor.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class FornecedorController : ControllerBase
{
    private readonly ILogger<FornecedorController> _logger;

    public FornecedorController(ILogger<FornecedorController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Create a new supplier.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create()
    {
        return Ok();
    }

    /// <summary>
    /// Get all suppliers.
    /// </summary>
    /// <returns></returns>
    [HttpGet]    
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    /// <summary>
    /// Get supplier by Id.
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]    
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok();
    }

    /// <summary>
    /// Update supplier data.
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}")]    
    public async Task<IActionResult> Update(Guid id, [FromBody] SupplierUpdateViewModel viewModel)
    {
        return Ok();
    }
    
    /// <summary>
    /// Delete supplier.
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}")]    
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok();
    }
}

