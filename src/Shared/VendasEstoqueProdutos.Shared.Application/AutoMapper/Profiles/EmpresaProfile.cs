using AutoMapper;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Empresa;
using VendasEstoqueProdutos.Shared.Domain.Entities;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Profiles;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<Empresa, ReadEmpresaDto>();
        CreateMap<Empresa, ReadEmpresaCompletoDto>();
    }
}
