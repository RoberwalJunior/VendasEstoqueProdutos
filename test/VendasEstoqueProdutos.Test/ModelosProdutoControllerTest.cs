using System.Net;
using System.Net.Http.Json;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;
using VendasEstoqueProdutos.Test.WebApplication;

namespace VendasEstoqueProdutos.Test;

public class ModelosProdutoControllerTest(VendasEstoqueProdutosApplicationFactory app)
        : IClassFixture<VendasEstoqueProdutosApplicationFactory>
{
    private readonly VendasEstoqueProdutosApplicationFactory _app = app;
    private readonly string URL = $"/api/produtos/modelos/";

    [Fact]
    public async Task GET_RecuperarListaDeModelosProdutosCadastrados()
    {
        using var client = _app.CreateClient();

        var listaProdutosDto = await client.GetFromJsonAsync<IEnumerable<ReadModeloProdutoDto>>(URL);

        Assert.NotNull(listaProdutosDto);
    }

    [Fact]
    public async Task GET_RecuperarModeloProdutoPeloId()
    {
        using var client = _app.CreateClient();
        var modeloProdutoExitente = await _app.RecuperarModeloProdutoExistente();

        var modeloProdutoDto = await client.GetFromJsonAsync<ReadModeloProdutoDto>($"{URL}{modeloProdutoExitente.Id}");

        Assert.NotNull(modeloProdutoExitente);
        Assert.Equal(modeloProdutoExitente.Produto!.Id, modeloProdutoDto!.ProdutoId);
        Assert.Equal(modeloProdutoExitente.Descricao, modeloProdutoDto!.Descricao);
        Assert.Equal(modeloProdutoExitente.QuantidadeEstoque, modeloProdutoDto!.QuantidadeEstoque);
    }

    [Fact]
    public async Task POST_Retornar_Status_Ok_Quando_Cadastra_Modelo_Produto_Com_Exito()
    {
        var produtoExitente = await _app.RecuperarProdutoExistente();
        var modeloProdutoDto = new CreateModeloProdutoDto()
        {
            ProdutoId = produtoExitente.Id,
            Descricao = "Descrição modelo produto teste",
            QuantidadeEstoque = 50
        };
        using var client = _app.CreateClient();

        var result = await client.PostAsJsonAsync(URL, modeloProdutoDto);

        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task POST_Retornar_Status_NoContent_Quando_Atualiza_Modelo_Produto_Com_Exito()
    {
        var modeloProdutoExitente = await _app.RecuperarModeloProdutoExistente();
        var modeloProdutoDto = new UpdateModeloProdutoDto()
        {
            Descricao = "Descrição modelo produto teste",
            QuantidadeEstoque = 50
        };
        using var client = _app.CreateClient();

        var result = await client.PutAsJsonAsync($"{URL}{modeloProdutoExitente.Id}", modeloProdutoDto);

        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }

    [Fact]
    public async Task POST_Retornar_Status_NoContent_Quando_Deletar_Modelo_Produto_Com_Exito()
    {
        var modeloProdutoExitente = await _app.RecuperarModeloProdutoExistente();
        using var client = _app.CreateClient();

        var result = await client.DeleteAsync($"{URL}{modeloProdutoExitente.Id}");

        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }
}
