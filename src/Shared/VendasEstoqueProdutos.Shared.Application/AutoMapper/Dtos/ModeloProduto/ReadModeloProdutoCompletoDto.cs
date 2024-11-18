using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;

public class ReadModeloProdutoCompletoDto
{
    public string? Descricao { get; set; }
    public int QuantidadeEstoque { get; set; }
    public ReadProdutoDto? Produto { get; set; }
}
