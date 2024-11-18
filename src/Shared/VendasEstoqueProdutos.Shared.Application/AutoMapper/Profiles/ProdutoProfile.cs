using AutoMapper;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;
using VendasEstoqueProdutos.Shared.Domain.Entities;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<Produto, ReadProdutoDto>();
        CreateMap<Produto, ReadProdutoCompletoDto>();
        CreateMap<UpdateProdutoDto, Produto>();
    }
}
