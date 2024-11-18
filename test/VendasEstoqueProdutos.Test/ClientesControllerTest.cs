using System.Net.Http.Json;
using VendasEstoqueProdutos.Test.WebApplication;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;

namespace VendasEstoqueProdutos.Test;

public class ClientesControllerTest(VendasEstoqueProdutosApplicationFactory app)
        : IClassFixture<VendasEstoqueProdutosApplicationFactory>
{
    private readonly VendasEstoqueProdutosApplicationFactory _app = app;

    [Fact]
    public async Task GET_RecuperarListaDeClientesCadastrados()
    {
        using var client = _app.CreateClient();

        var listaclientesDto = await client.GetFromJsonAsync<IEnumerable<ReadClienteDto>>("/api/clientes");

        Assert.NotNull(listaclientesDto);
    }

    [Fact]
    public async Task GET_RecuperarClientePeloId()
    {
        using var client = _app.CreateClient();
        var clienteExistente = await _app.RecuperarClienteExistente();

        var clienteDto = await client.GetFromJsonAsync<ReadClienteCompletoDto>($"/api/clientes/{clienteExistente.Id}");

        Assert.NotNull(clienteDto);
        Assert.Equal(clienteExistente.Nome, clienteDto.Nome);
        Assert.Equal(clienteExistente.RazaoSocial, clienteDto.RazaoSocial);
        Assert.Equal(clienteExistente.Cnpj, clienteDto.Cnpj);
        Assert.NotNull(clienteDto.Empresa);
        Assert.Equal(clienteExistente.Empresa!.Nome, clienteDto!.Empresa.Nome);
    }
}
