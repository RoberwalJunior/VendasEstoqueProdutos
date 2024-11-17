using Microsoft.EntityFrameworkCore;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Context;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories.Model;

namespace VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories.Base;

public abstract class BaseRepository<T>(AppDbContext context) : IModelRepository<T> where T : class
{
    protected readonly AppDbContext _context = context;

    public async Task<IEnumerable<T>> GetAll(Func<T, bool> predicate = null!)
    {
        try
        {
            var list = await _context.Set<T>().ToListAsync();
            if (predicate != null)
            {
                list = list.Where(predicate).ToList();
            }
            return list;
        }
        catch
        {
            throw new Exception("Erro ao obter a lista de entidade");
        }
    }

    public virtual T? GetById(int id)
    {
        try
        {
            T? model = _context.Set<T>().Find(id);
            return model;
        }
        catch
        {
            throw new Exception($"Erro ao obter entidade com Id = {id}.");
        }
    }

    public async Task<bool> CreateAsync(T model)
    {
        try
        {
            await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(T model)
    {
        try
        {
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            T? model = GetById(id);
            if (model == null) return false;
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
