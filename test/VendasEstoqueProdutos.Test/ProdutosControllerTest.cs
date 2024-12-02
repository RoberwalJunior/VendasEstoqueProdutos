﻿using System.Net;
using System.Net.Http.Json;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;
using VendasEstoqueProdutos.Test.WebApplication;

namespace VendasEstoqueProdutos.Test;

public class ProdutosControllerTest(VendasEstoqueProdutosApplicationFactory app)
        : IClassFixture<VendasEstoqueProdutosApplicationFactory>
{
    private readonly VendasEstoqueProdutosApplicationFactory _app = app;

    [Fact]
    public async Task GET_RecuperarListaDeProdutosCadastrados()
    {
        using var client = _app.CreateClient();

        var listaProdutosDto = await client.GetFromJsonAsync<IEnumerable<ReadProdutoDto>>("/api/produtos");

        Assert.NotNull(listaProdutosDto);
    }

    [Fact]
    public async Task GET_RecuperarProdutoPeloId()
    {
        using var client = _app.CreateClient();
        var produtoExitente = await _app.RecuperarProdutoExistente();

        var produtoDto = await client.GetFromJsonAsync<ReadProdutoCompletoDto>($"/api/produtos/{produtoExitente.Id}");

        Assert.NotNull(produtoDto);
        Assert.Equal(produtoExitente.Codigo, produtoDto.Codigo);
        Assert.Equal(produtoExitente.Nome, produtoDto.Nome);
        Assert.Equal(produtoExitente.ValorUnitario, produtoDto.ValorUnitario);
        Assert.NotNull(produtoDto.Modelos);
        Assert.NotNull(produtoDto.Empresa);
        Assert.Equal(produtoExitente.Empresa!.Nome, produtoDto.Empresa.Nome);
    }

    [Fact]
    public async Task GET_RecuperarListaDeModelosDoProduto()
    {
        using var client = _app.CreateClient();
        var produtoExitente = await _app.RecuperarProdutoExistente();

        var listaModeloProdutoDto = await client.GetFromJsonAsync<IEnumerable<ReadModeloDoProdutoDto>>($"/api/produtos/{produtoExitente.Id}/modelos");

        Assert.NotNull(listaModeloProdutoDto);
    }

    [Fact]
    public async Task POST_Retornar_Status_Ok_Quando_Cadastra_Produto_Com_Exito()
    {
        var empresaExistente = await _app.RecuperarEmpresaExistente();
        var produtoDto = new CreateProdutoDto()
        {
            EmpresaId = empresaExistente.Id,
            Codigo = 999,
            Nome = "Produto para teste de API",
            ValorUnitario = 59.99
        };
        using var client = _app.CreateClient();

        var result = await client.PostAsJsonAsync("/api/produtos", produtoDto);

        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task PUT_Retornar_Status_NoContent_Quando_Atualiza_Produto_Com_Exito()
    {
        var produtoExitente = await _app.RecuperarProdutoExistente();
        var produtoDto = new UpdateProdutoDto()
        {
            Codigo = 999,
            Nome = "Produto para teste de API",
            ValorUnitario = 59.99
        };
        using var client = _app.CreateClient();

        var result = await client.PutAsJsonAsync($"/api/produtos/{produtoExitente.Id}", produtoDto);

        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }

    [Fact]
    public async Task DELETE_Retornar_Status_NoContent_Quando_Deletar_Produto_Com_Exito()
    {
        var produtoExitente = await _app.RecuperarProdutoExistente();
        using var client = _app.CreateClient();

        var result = await client.DeleteAsync($"/api/produtos/{produtoExitente.Id}");

        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }
}
