using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Venda;

namespace VendasEstoqueProdutos.Shared.Application.Interfaces;

public interface IVendaServiceApp
{
    public Task<IEnumerable<ReadVendaDto>> RecuperarListaDeVendasCadastradas();
    public ReadVendaDto? RecuperarVendaPeloId(int id);
}
