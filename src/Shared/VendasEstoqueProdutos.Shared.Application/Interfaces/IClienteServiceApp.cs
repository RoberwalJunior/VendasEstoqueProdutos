using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;

namespace VendasEstoqueProdutos.Shared.Application.Interfaces;

public interface IClienteServiceApp
{
    public Task<IEnumerable<ReadClienteDto>> RecuperarListaDeClientesCadastrados();
    public ReadClienteCompletoDto? RecuperarClientePeloId(int id);
    public Task<bool> CadastrarNovoCliente(CreateClienteDto clienteDto);
    public Task<bool> AtualizarCliente(int id, UpdateClienteDto clienteDto);
    public Task<bool> DeletarCliente(int id);
}
