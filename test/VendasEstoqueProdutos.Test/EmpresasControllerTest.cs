using System.Net.Http.Json;
using VendasEstoqueProdutos.Test.WebApplication;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Empresa;

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

        var empresaDto = await client.GetFromJsonAsync<ReadEmpresaDto>($"/api/empresas/{empresaExitente.Id}");

        Assert.NotNull(empresaExitente);
        Assert.Equal(empresaExitente.Nome, empresaDto!.Nome);
    }
}
