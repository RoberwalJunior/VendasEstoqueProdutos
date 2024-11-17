using AutoMapper;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Venda;
using VendasEstoqueProdutos.Shared.Application.Interfaces;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Services;

namespace VendasEstoqueProdutos.Shared.Application.ServiceApp;

public class VendaServiceApp(IMapper mapper, IVendaService vendaService) : IVendaServiceApp
{
    private readonly IMapper _mapper = mapper;
    private readonly IVendaService _vendaService = vendaService;

    public async Task<IEnumerable<ReadVendaDto>> RecuperarListaDeVendasCadastradas()
    {
        var lista = await _vendaService.GetModelsAsync();
        return _mapper.Map<IEnumerable<ReadVendaDto>>(lista);
    }

    public ReadVendaDto? RecuperarVendaPeloId(int id)
    {
        var venda = _vendaService.GetModelById(id);
        return venda != null ? _mapper.Map<ReadVendaDto>(venda) : null;
    }
}
