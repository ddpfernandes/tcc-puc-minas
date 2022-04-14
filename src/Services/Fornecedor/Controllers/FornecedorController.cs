using Microsoft.AspNetCore.Mvc;

namespace Fornecedor.Controllers;

[ApiController]
[Route("[controller]")]
public class FornecedorController : ControllerBase
{
    private readonly ILogger<FornecedorController> _logger;

    public FornecedorController(ILogger<FornecedorController> logger)
    {
        _logger = logger;
    }
}
