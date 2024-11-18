using Microsoft.AspNetCore.Mvc;
using VendasEstoqueProdutos.Shared.Application.Interfaces;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;

namespace VendasEstoqueProdutos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController(IProdutoServiceApp produtoService) : ControllerBase
{
    private readonly IProdutoServiceApp _produtoService = produtoService;

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
    public IActionResult RecuperarListaDeModelosDoProduto(int id)
    {
        var produto = _produtoService.RecuperarProdutoPeloId(id);
        return (produto != null && produto.Modelos != null) ? Ok(produto.Modelos) : NotFound("Produto não encontrado!");
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarNovoProduto([FromBody] CreateProdutoDto produtoDto)
    {
        var resultado = await _produtoService.CadastrarNovoProduto(produtoDto);
        return resultado ? Ok("Produto cadastrado com sucesso!") : StatusCode(500, new { Message = "Erro ao cadastrar novo produto." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
    {
        return await _produtoService.AtualizarProduto(id, produtoDto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarProduto(int id)
    {
        return await _produtoService.DeletarProduto(id) ? NoContent() : NotFound();
    }
}
