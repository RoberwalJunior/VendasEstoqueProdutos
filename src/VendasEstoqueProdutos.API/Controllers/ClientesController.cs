using Microsoft.AspNetCore.Mvc;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;
using VendasEstoqueProdutos.Shared.Application.Interfaces;

namespace VendasEstoqueProdutos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController(IClienteServiceApp clienteService) : ControllerBase
{
    private readonly IClienteServiceApp _clienteService = clienteService;

    [HttpGet]
    public async Task<IActionResult> RecuperarListaDeClientesCadastrados()
    {
        return Ok(await _clienteService.RecuperarListaDeClientesCadastrados());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarClientePeloId(int id)
    {
        var clienteDto = _clienteService.RecuperarClientePeloId(id);
        return clienteDto != null ? Ok(clienteDto) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarNovoCliente([FromBody] CreateClienteDto clienteDto)
    {
        var resultado = await _clienteService.CadastrarNovoCliente(clienteDto);
        return resultado ? Ok("Cliente cadastrado com sucesso!") : StatusCode(500, new { Message = "Erro ao cadastrar novo cliente." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarCliente(int id, [FromBody] UpdateClienteDto clienteDto)
    {
        return await _clienteService.AtualizarCliente(id, clienteDto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarCliente(int id)
    {
        return await _clienteService.DeletarCliente(id) ? NoContent() : NotFound();
    }
}
