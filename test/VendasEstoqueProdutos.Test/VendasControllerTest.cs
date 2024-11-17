using System.Net.Http.Json;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Venda;
using VendasEstoqueProdutos.Test.WebApplication;

namespace VendasEstoqueProdutos.Test;

public class VendasControllerTest(VendasEstoqueProdutosApplicationFactory app)
        : IClassFixture<VendasEstoqueProdutosApplicationFactory>
{
    private readonly VendasEstoqueProdutosApplicationFactory _app = app;

    [Fact]
    public async Task GET_RecuperarListaDeVendasRealizadas()
    {
        using var client = _app.CreateClient();

        var listaVendasDto = await client.GetFromJsonAsync<IEnumerable<ReadVendaDto>>("/api/vendas");

        Assert.NotNull(listaVendasDto);
    }

    [Fact]
    public async Task GET_RecuperarEmpresaPeloId()
    {
        using var client = _app.CreateClient();
        var vendaExitente = await _app.RecuperarVendaExistente();

        var vendaDto = await client.GetFromJsonAsync<ReadVendaDto>($"/api/vendas/{vendaExitente.Id}");

        Assert.NotNull(vendaExitente);
        Assert.Equal(vendaExitente.Empresa!.Id, vendaDto!.EmpresaId);
        Assert.Equal(vendaExitente.ValorTotal, vendaDto!.ValorTotal);
        Assert.Equal(vendaExitente.DataDaCompra, vendaDto!.DataDaCompra);
    }
}
