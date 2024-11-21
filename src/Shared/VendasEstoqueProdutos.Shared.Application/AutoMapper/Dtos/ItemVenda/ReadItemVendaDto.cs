namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ItemVenda;

public class ReadItemVendaDto
{
    public int Id { get; set; }
    public int VendaId { get; set; }
    public int ModeloProdutoId { get; set; }
    public int Quantidade { get; set; }
    public double Valor { get; set; }
}
