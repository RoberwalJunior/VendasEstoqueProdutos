using VendasEstoqueProdutos.Shared.Domain.Interfaces.Services.Model;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories.Model;

namespace VendasEstoqueProdutos.Shared.Domain.Services.Base;

public abstract class BaseService<T>(IModelRepository<T> repository)
    : IModelService<T> where T : class
{
    protected readonly IModelRepository<T> _repository = repository;

    public async Task<IEnumerable<T>> GetModelsAsync()
    {
        return await _repository.GetAll();
    }

    public T? GetModelById(int id)
    {
        return _repository.GetById(id);
    }

    public async Task<bool> CreateModel(T model)
    {
        return await _repository.CreateAsync(model);
    }

    public async Task<bool> UpdateModel(T model)
    {
        return await _repository.UpdateAsync(model);
    }

    public async Task<bool> DeleteModel(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
