using AutoMapper;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ItemVenda;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Profiles;

public class ItemVendaProfile : Profile
{
    public ItemVendaProfile()
    {
        CreateMap<ItemVenda, ReadItemVendaDto>();
    }
}
