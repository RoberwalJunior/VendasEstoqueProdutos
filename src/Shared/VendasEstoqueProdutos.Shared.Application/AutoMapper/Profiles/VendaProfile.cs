using AutoMapper;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Venda;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Profiles;

public class VendaProfile : Profile
{
    public VendaProfile()
    {
        CreateMap<Venda, ReadVendaDto>();
    }
}
