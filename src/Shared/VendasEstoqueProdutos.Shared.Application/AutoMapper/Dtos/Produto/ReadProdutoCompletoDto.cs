using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Empresa;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;

public class ReadProdutoCompletoDto
{
    public int Codigo { get; set; }
    public string? Nome { get; set; }
    public double ValorUnitario { get; set; }
    public ReadEmpresaDto? Empresa { get; set; }
    public ICollection<ReadModeloProdutoDto>? Modelos { get; set; }
}
