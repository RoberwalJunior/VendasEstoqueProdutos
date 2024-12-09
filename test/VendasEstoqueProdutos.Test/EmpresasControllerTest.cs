﻿using System.Net.Http.Json;
using VendasEstoqueProdutos.Test.WebApplication;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Empresa;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Venda;

namespace VendasEstoqueProdutos.Test;

public class EmpresasControllerTest(VendasEstoqueProdutosApplicationFactory app)
        : IClassFixture<VendasEstoqueProdutosApplicationFactory>
{
    private readonly VendasEstoqueProdutosApplicationFactory _app = app;

    [Fact]
    public async Task GET_RecuperarListaDeEmpresasCadastrados()
    {
        using var client = _app.CreateClient();

        var listaEmpresasDto = await client.GetFromJsonAsync<IEnumerable<ReadEmpresaDto>>("/api/empresas");

        Assert.NotNull(listaEmpresasDto);
    }

    [Fact]
    public async Task GET_RecuperarEmpresaPeloId()
    {
        using var client = _app.CreateClient();
        var empresaExitente = await _app.RecuperarEmpresaExistente();

        var empresaDto = await client.GetFromJsonAsync<ReadEmpresaCompletoDto>($"/api/empresas/{empresaExitente.Id}");

        Assert.NotNull(empresaDto);
        Assert.Equal(empresaExitente.Nome, empresaDto.Nome);
        Assert.Equal(empresaExitente.RazaoSocial, empresaDto.RazaoSocial);
        Assert.Equal(empresaExitente.Cnpj, empresaDto.Cnpj);
        Assert.NotNull(empresaDto.Clientes);
        Assert.NotNull(empresaDto.Produtos);
        Assert.NotNull(empresaDto.Vendas);
    }

    [Fact]
    public async Task GET_RecuperarListaProdutosDaEmpresaCadastrados()
    {
        using var client = _app.CreateClient();
        var empresaExitente = await _app.RecuperarEmpresaExistente();

        var listaProdutosDaEmpresaDto = await client.GetFromJsonAsync<IEnumerable<ReadProdutoEmpresaDto>>($"/api/empresas/{empresaExitente.Id}/produtos");

        Assert.NotNull(listaProdutosDaEmpresaDto);
    }

    [Fact]
    public async Task GET_RecuperarListaClientesDaEmpresaCadastrados()
    {
        using var client = _app.CreateClient();
        var empresaExitente = await _app.RecuperarEmpresaExistente();

        var listaClientesDaEmpresaDto = await client.GetFromJsonAsync<IEnumerable<ReadClienteEmpresaDto>>($"/api/empresas/{empresaExitente.Id}/clientes");

        Assert.NotNull(listaClientesDaEmpresaDto);
    }

    [Fact]
    public async Task GET_RecuperarListaDeVendasDaEmpresaCadastrados()
    {
        using var client = _app.CreateClient();
        var empresaExitente = await _app.RecuperarEmpresaExistente();

        var listaVendasDaEmpresaDto = await client.GetFromJsonAsync<IEnumerable<ReadVendaEmpresaDto>>($"/api/empresas/{empresaExitente.Id}/vendas");

        Assert.NotNull(listaVendasDaEmpresaDto);
    }
}
