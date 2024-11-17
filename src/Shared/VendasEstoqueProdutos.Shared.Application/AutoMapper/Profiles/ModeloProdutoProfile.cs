using AutoMapper;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;
using VendasEstoqueProdutos.Shared.Domain.Entities;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Profiles;

public class ModeloProdutoProfile : Profile
{
    public ModeloProdutoProfile()
    {
        CreateMap<CreateModeloProdutoDto, ModeloProduto>();
        CreateMap<ModeloProduto, ReadModeloProdutoDto>();
        CreateMap<UpdateModeloProdutoDto, ModeloProduto>();
    }
}
