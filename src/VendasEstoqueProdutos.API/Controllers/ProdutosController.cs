using Microsoft.AspNetCore.Mvc;
using VendasEstoqueProdutos.Shared.Application.Interfaces;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;

namespace VendasEstoqueProdutos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController(IProdutoServiceApp produtoService, IModeloProdutoServiceApp modeloProdutoService) : ControllerBase
{
    private readonly IProdutoServiceApp _produtoService = produtoService;
    private readonly IModeloProdutoServiceApp _modeloProdutoService = modeloProdutoService;

    [HttpGet]
    public async Task<IActionResult> RecuperarListaDeProdutosCadastrados()
    {
        return Ok(await _produtoService.RecuperarListaDeProdutosCadastrados());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarProdutoCadastradoPeloId(int id)
    {
        var produto = _produtoService.RecuperarProdutoPeloId(id);
        return produto != null ? Ok(produto) : NotFound();
    }

    [HttpGet("{id}/Modelos")]
    public async Task<IActionResult> RecuperarListaDeModelosDoProduto(int id)
    {
        if (_produtoService.RecuperarProdutoPeloId(id) == null) return NotFound("Produto não encontrado!");
        return Ok(await _modeloProdutoService.RecuperarListaDeModelosDoProduto(id));
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarNovoProduto([FromBody] CreateProdutoDto produtoDto)
    {
        var resultado = await _produtoService.CadastrarNovoProduto(produtoDto);
        return resultado ? Ok("Produto cadastrado com sucesso!") : StatusCode(500, new { Message = "Erro ao cadastrar novo produto." });
    }
}
