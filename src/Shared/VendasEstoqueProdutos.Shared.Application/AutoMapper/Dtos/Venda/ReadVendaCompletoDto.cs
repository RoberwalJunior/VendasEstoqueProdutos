using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Empresa;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ItemVenda;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Venda;

public class ReadVendaCompletoDto
{
    public double ValorTotal { get; set; }
    public DateTime DataDaCompra { get; set; }
    public string? TipoPagamento { get; set; }
    public string? StatusPagamento { get; set; }
    public ReadEmpresaDto? Empresa { get; set; }
    public ReadClienteDto? Cliente { get; set; }
    public ICollection<ReadItemVendaDto>? Itens { get; set; }
}
