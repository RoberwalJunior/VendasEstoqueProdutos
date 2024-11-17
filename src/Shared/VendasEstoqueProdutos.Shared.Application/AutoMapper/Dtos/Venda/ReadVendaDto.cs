using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ItemVenda;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Venda;

public class ReadVendaDto
{
    public int Id { get; set; }
    public int EmpresaId { get; set; }
    public int ClienteId { get; set; }
    public double ValorTotal { get; set; }
    public DateTime DataDaCompra { get; set; }
    public int TipoPagamento { get; set; }
    public int StatusPagamento { get; set; }
    public ICollection<ReadItemVendaDto>? Itens { get; set; }
}
