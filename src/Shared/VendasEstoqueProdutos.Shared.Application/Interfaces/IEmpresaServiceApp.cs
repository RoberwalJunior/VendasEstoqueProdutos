using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Empresa;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;

namespace VendasEstoqueProdutos.Shared.Application.Interfaces;

public interface IEmpresaServiceApp
{
    public Task<IEnumerable<ReadEmpresaDto>> RecuperarListaDeEmpresasCadastradas();
    public ReadEmpresaDto? RecuperarEmpresaPeloId(int id);
    public IEnumerable<ReadProdutoDto>? RecuperarListaDeProdutosDaEmpresa(int id);
}
