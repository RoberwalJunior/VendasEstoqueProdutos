using AutoMapper;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;
using VendasEstoqueProdutos.Shared.Application.Interfaces;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Services;

namespace VendasEstoqueProdutos.Shared.Application.ServiceApp;

public class ModeloProdutoServiceApp(IMapper mapper, IModeloProdutoService modeloProdutoService) : IModeloProdutoServiceApp
{
    private readonly IMapper _mapper = mapper;
    private readonly IModeloProdutoService _modeloProdutoService = modeloProdutoService;

    public async Task<IEnumerable<ReadModeloProdutoDto>> RecuperarListaDeTodosOsModelosDoProduto()
    {
        var listaModelosProduto = await _modeloProdutoService.GetModelsAsync();
        return _mapper.Map<IEnumerable<ReadModeloProdutoDto>>(listaModelosProduto);
    }

    public async Task<IEnumerable<ReadModeloProdutoDto>> RecuperarListaDeModelosDoProduto(int produtoId)
    {
        var listaModelosProduto = await _modeloProdutoService.GetAllModelosProduto(produtoId);
        return _mapper.Map<IEnumerable<ReadModeloProdutoDto>>(listaModelosProduto);
    }

    public ReadModeloProdutoCompletoDto? RecuperarModeloProdutoPeloId(int id)
    {
        var modeloProduto = _modeloProdutoService.GetModelById(id);
        return modeloProduto != null ? _mapper.Map<ReadModeloProdutoCompletoDto>(modeloProduto) : null;
    }

    public async Task<bool> CadastrarNovoModeloProduto(CreateModeloProdutoDto modeloProdutoDto)
    {
        var modeloProduto = _mapper.Map<ModeloProduto>(modeloProdutoDto);
        return await _modeloProdutoService.CreateModel(modeloProduto);
    }

    public async Task<bool> AtualizarModeloProduto(int id, UpdateModeloProdutoDto modeloProdutoDto)
    {
        var modeloProduto = _modeloProdutoService.GetModelById(id);
        if (modeloProduto == null) return false;
        _mapper.Map(modeloProdutoDto, modeloProduto);
        return await _modeloProdutoService.UpdateModel(modeloProduto);
    }

    public async Task<bool> DeletarModeloProduto(int id)
    {
        return await _modeloProdutoService.DeleteModel(id);
    }
}
