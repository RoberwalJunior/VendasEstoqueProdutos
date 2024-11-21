namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;

public class ReadProdutoEmpresaDto
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string? Nome { get; set; }
    public double ValorUnitario { get; set; }
}
