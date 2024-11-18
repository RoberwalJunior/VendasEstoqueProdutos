using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Venda;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Empresa;

public class ReadEmpresaCompletoDto
{
    public string? Nome { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; set; }
    public ICollection<ReadClienteDto>? Clientes { get; set; }
    public ICollection<ReadProdutoDto>? Produtos { get; set; }
    public ICollection<ReadVendaDto>? Vendas { get; set; }
}
