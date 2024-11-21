namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;

public class ReadModeloDoProdutoDto
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public int QuantidadeEstoque { get; set; }
}
