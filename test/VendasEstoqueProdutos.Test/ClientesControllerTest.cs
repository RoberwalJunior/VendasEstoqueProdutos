using System.Net.Http.Json;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;
using VendasEstoqueProdutos.Test.WebApplication;

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

        var clienteDto = await client.GetFromJsonAsync<ReadClienteDto>($"/api/clientes/{clienteExistente.Id}");

        Assert.NotNull(clienteExistente);
        Assert.Equal(clienteExistente.Empresa!.Id, clienteDto!.EmpresaId);
        Assert.Equal(clienteExistente.Nome, clienteDto!.Nome);
    }
}
