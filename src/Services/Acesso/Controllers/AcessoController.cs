using Microsoft.AspNetCore.Mvc;

namespace Acesso.Controllers;

[ApiController]
[Route("[controller]")]
public class AcessoController : ControllerBase
{
    private readonly ILogger<AcessoController> _logger;

    public AcessoController(ILogger<AcessoController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar()
    {
        return Ok();
    }
}
