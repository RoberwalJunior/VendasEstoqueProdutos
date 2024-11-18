using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Empresa;

namespace VendasEstoqueProdutos.Shared.Application.Interfaces;

public interface IEmpresaServiceApp
{
    public Task<IEnumerable<ReadEmpresaDto>> RecuperarListaDeEmpresasCadastradas();
    public ReadEmpresaCompletoDto? RecuperarEmpresaPeloId(int id);
}
