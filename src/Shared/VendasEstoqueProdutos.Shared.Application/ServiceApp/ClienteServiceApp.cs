using AutoMapper;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;
using VendasEstoqueProdutos.Shared.Application.Interfaces;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Services;

namespace VendasEstoqueProdutos.Shared.Application.ServiceApp;

public class ClienteServiceApp(IMapper mapper, IClienteService clienteService) : IClienteServiceApp
{
    private readonly IMapper _mapper = mapper;
    private readonly IClienteService _clienteService = clienteService;

    public async Task<IEnumerable<ReadClienteDto>> RecuperarListaDeClientesCadastrados()
    {
        var lista = await _clienteService.GetModelsAsync();
        return _mapper.Map<IEnumerable<ReadClienteDto>>(lista);
    }

    public ReadClienteDto? RecuperarClientePeloId(int id)
    {
        var empresa = _clienteService.GetModelById(id);
        return empresa != null ? _mapper.Map<ReadClienteDto>(empresa) : null;
    }

    public async Task<bool> CadastrarNovoCliente(CreateClienteDto clienteDto)
    {
        var cliente = _mapper.Map<Cliente>(clienteDto);
        return await _clienteService.CreateModel(cliente);
    }

    public async Task<bool> AtualizarCliente(int id, UpdateClienteDto clienteDto)
    {
        var cliente = _clienteService.GetModelById(id);
        if (cliente == null) return false;
        _mapper.Map(clienteDto, cliente);
        return await _clienteService.UpdateModel(cliente);
    }

    public async Task<bool> DeletarCliente(int id)
    {
        return await _clienteService.DeleteModel(id);
    }
}
