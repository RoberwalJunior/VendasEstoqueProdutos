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
        CreateMap<ModeloProduto, ReadModeloProdutoCompletoDto>();
        CreateMap<ModeloProduto, ReadModeloDoProdutoDto>();
        CreateMap<UpdateModeloProdutoDto, ModeloProduto>();
    }
}
