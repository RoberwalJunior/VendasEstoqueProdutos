namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;

public class ReadProdutoDto
{
    public int Id { get; set; }
    public int EmpresaId { get; set; }
    public int Codigo { get; set; }
    public string? Nome { get; set; }
    public double ValorUnitario { get; set; }
}
