using Microsoft.EntityFrameworkCore;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Context;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories.Base;

namespace VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories;

public class ModeloProdutoRepository(AppDbContext context)
    : BaseRepository<ModeloProduto>(context), IModeloProdutoRepository
{
    public override ModeloProduto? GetById(int id)
    {
        return _context.ModeloProdutos
            .Include(modelo => modelo.Produto)
            .AsNoTracking()
            .FirstOrDefault(modelo => modelo.Id == id);
    }
}
