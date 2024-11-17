using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Services.Base;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Services;

namespace VendasEstoqueProdutos.Shared.Domain.Services;

public class ModeloProdutoService(IModeloProdutoRepository repository)
    : BaseService<ModeloProduto>(repository), IModeloProdutoService
{
    public async Task<IEnumerable<ModeloProduto>> GetAllModelosProduto(int produtoId)
    {
        return await _repository.GetAll(modeloProduto => modeloProduto.ProdutoId == produtoId);
    }
}
