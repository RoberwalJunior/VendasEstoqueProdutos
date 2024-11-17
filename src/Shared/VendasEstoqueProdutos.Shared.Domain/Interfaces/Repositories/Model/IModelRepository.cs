namespace VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories.Model;

public interface IModelRepository<T> : IDisposable where T : class
{
    public Task<IEnumerable<T>> GetAll(Func<T, bool> predicate = null!);
    public T? GetById(int id);
    public Task<bool> CreateAsync(T model);
    public Task<bool> UpdateAsync(T model);
    public Task<bool> DeleteAsync(int id);
}
