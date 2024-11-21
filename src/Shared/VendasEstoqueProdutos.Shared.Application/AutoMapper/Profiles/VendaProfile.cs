using AutoMapper;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Venda;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Profiles;

public class VendaProfile : Profile
{
    public VendaProfile()
    {
        CreateMap<Venda, ReadVendaDto>();
        CreateMap<Venda, ReadVendaEmpresaDto>();
        CreateMap<Venda, ReadVendaCompletoDto>()
            .ForMember(vendaDto => vendaDto.TipoPagamento,
                opt => opt.MapFrom(venda => venda.TipoPagamento.ToString()))
            .ForMember(vendaDto => vendaDto.StatusPagamento,
                opt => opt.MapFrom(venda => venda.StatusPagamento.ToString()));
    }
}
