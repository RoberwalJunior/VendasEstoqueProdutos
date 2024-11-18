using AutoMapper;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Empresa;
using VendasEstoqueProdutos.Shared.Application.Interfaces;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Services;

namespace VendasEstoqueProdutos.Shared.Application.ServiceApp;

public class EmpresaServiceApp(IMapper mapper, IEmpresaService service) : IEmpresaServiceApp
{
    private readonly IMapper _mapper = mapper;
    private readonly IEmpresaService _service = service;

    public async Task<IEnumerable<ReadEmpresaDto>> RecuperarListaDeEmpresasCadastradas()
    {
        var lista = await _service.GetModelsAsync();
        return _mapper.Map<IEnumerable<ReadEmpresaDto>>(lista);
    }

    public ReadEmpresaCompletoDto? RecuperarEmpresaPeloId(int id)
    {
        var empresa = _service.GetModelById(id);
        return empresa != null ? _mapper.Map<ReadEmpresaCompletoDto>(empresa) : null;
    }
}
