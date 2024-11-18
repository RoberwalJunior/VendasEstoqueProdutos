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

    [HttpGet("{id}/Produtos")]
    public IActionResult RecuperarListaDeProdutosDaEmpresa(int id)
    {
        var empresaDto = _empresaService.RecuperarEmpresaPeloId(id);
        return (empresaDto != null && empresaDto.Produtos != null) ? Ok(empresaDto.Produtos) : NotFound();
    }

    [HttpGet("{id}/Clientes")]
    public IActionResult RecuperarListaDeClientesDaEmpresa(int id)
    {
        var empresaDto = _empresaService.RecuperarEmpresaPeloId(id);
        return (empresaDto != null && empresaDto.Clientes != null) ? Ok(empresaDto.Clientes) : NotFound();
    }

    [HttpGet("{id}/Vendas")]
    public IActionResult RecuperarListaDeVendasCadastradasDaEmpresa(int id)
    {
        var empresaDto = _empresaService.RecuperarEmpresaPeloId(id);
        return (empresaDto != null && empresaDto.Vendas != null) ? Ok(empresaDto.Vendas) : NotFound();
    }
}
