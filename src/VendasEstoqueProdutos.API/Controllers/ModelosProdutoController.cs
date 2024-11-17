using Microsoft.AspNetCore.Mvc;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;
using VendasEstoqueProdutos.Shared.Application.Interfaces;

namespace VendasEstoqueProdutos.API.Controllers;

[ApiController]
[Route("api/produtos/modelos")]
public class ModelosProdutoController(IModeloProdutoServiceApp modeloProdutoService) : ControllerBase
{
    private readonly IModeloProdutoServiceApp _modeloProdutoService = modeloProdutoService;

    [HttpGet]
    public async Task<IActionResult> RecuperarListaDeTodosOsModelosDoProduto()
    {
        return Ok(await _modeloProdutoService.RecuperarListaDeTodosOsModelosDoProduto());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarProdutoCadastradoPeloId(int id)
    {
        var modeloProduto = _modeloProdutoService.RecuperarModeloProdutoPeloId(id);
        return modeloProduto != null ? Ok(modeloProduto) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarNovoModeloDoProduto([FromBody] CreateModeloProdutoDto modeloProdutoDto)
    {
        var resultado = await _modeloProdutoService.CadastrarNovoModeloProduto(modeloProdutoDto);
        return resultado ? Ok("Modelo do cadastrado com sucesso!") : StatusCode(500, new { Message = "Erro ao cadastrar novo modelo do produto." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarModeloProduto(int id, [FromBody] UpdateModeloProdutoDto modeloProdutoDto)
    {
        return await _modeloProdutoService.AtualizarModeloProduto(id, modeloProdutoDto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarModeloProduto(int id)
    {
        return await _modeloProdutoService.DeletarModeloProduto(id) ? NoContent() : NotFound();
    }
}
