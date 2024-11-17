namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;

public class ReadModeloProdutoDto
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public string? Descricao { get; set; }
    public int QuantidadeEstoque { get; set; }
}
