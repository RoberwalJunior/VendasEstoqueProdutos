namespace VendasEstoqueProdutos.Shared.Domain.Interfaces.Services.Model;

public interface IModelService<T> where T : class
{
    public Task<IEnumerable<T>> GetModelsAsync();
    public T? GetModelById(int id);
    public Task<bool> CreateModel(T model);
    public Task<bool> UpdateModel(T model);
    public Task<bool> DeleteModel(int id);
}
