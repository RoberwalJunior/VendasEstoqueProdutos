using Microsoft.AspNetCore.Mvc;
using VendasEstoqueProdutos.Shared.Application.Interfaces;

namespace VendasEstoqueProdutos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendasController(IVendaServiceApp vendaService) : ControllerBase
{
    private readonly IVendaServiceApp _vendaService = vendaService;

    [HttpGet]
    public async Task<IActionResult> RecuperarListaDeVendasCadastradas()
    {
        return Ok(await _vendaService.RecuperarListaDeVendasCadastradas());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarVendaPeloId(int id)
    {
        var vendaDto = _vendaService.RecuperarVendaPeloId(id);
        return vendaDto != null ? Ok(vendaDto) : NotFound();
    }
}
