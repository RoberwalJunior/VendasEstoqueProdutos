using AutoMapper;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;
using VendasEstoqueProdutos.Shared.Domain.Entities;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<Cliente, ReadClienteDto>();
    }
}
