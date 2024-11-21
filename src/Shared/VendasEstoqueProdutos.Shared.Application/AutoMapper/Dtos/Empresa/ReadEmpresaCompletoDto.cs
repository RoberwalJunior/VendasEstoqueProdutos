using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Venda;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Empresa;

public class ReadEmpresaCompletoDto
{
    public string? Nome { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; set; }
    public ICollection<ReadClienteEmpresaDto>? Clientes { get; set; }
    public ICollection<ReadProdutoEmpresaDto>? Produtos { get; set; }
    public ICollection<ReadVendaEmpresaDto>? Vendas { get; set; }
}
