using Microsoft.AspNetCore.Mvc;
using VendasEstoqueProdutos.Shared.Application.Interfaces;

namespace VendasEstoqueProdutos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpresasController(IEmpresaServiceApp empresaService) : ControllerBase
{
    private readonly IEmpresaServiceApp _empresaService = empresaService;

    [HttpGet]
    public async Task<IActionResult> RecuperarListaDeEmpresasCadastradas()
    {
        return Ok(await _empresaService.RecuperarListaDeEmpresasCadastradas());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarEmpresaPeloId(int id)
    {
        var empresaDto = _empresaService.RecuperarEmpresaPeloId(id);
        return empresaDto != null ? Ok(empresaDto) : NotFound();
    }
}
