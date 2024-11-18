using System.Net.Http.Json;
using VendasEstoqueProdutos.Test.WebApplication;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Venda;

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

        var vendaDto = await client.GetFromJsonAsync<ReadVendaCompletoDto>($"/api/vendas/{vendaExitente.Id}");

        Assert.NotNull(vendaDto);
        Assert.Equal(vendaExitente.ValorTotal, vendaDto.ValorTotal);
        Assert.Equal(vendaExitente.DataDaCompra, vendaDto.DataDaCompra);
        Assert.NotNull(vendaDto.Empresa);
        Assert.Equal(vendaExitente.Empresa!.Nome, vendaDto.Empresa.Nome);
        Assert.NotNull(vendaDto.Itens);
    }
}
