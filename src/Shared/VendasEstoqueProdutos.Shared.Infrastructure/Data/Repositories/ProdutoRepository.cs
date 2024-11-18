using Microsoft.EntityFrameworkCore;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Context;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories.Base;

namespace VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories;

public class ProdutoRepository(AppDbContext context)
    : BaseRepository<Produto>(context), IProdutoRepository
{
    public override Produto? GetById(int id)
    {
        return _context.Produtos
            .Include(produto => produto.Empresa)
            .Include(produto => produto.Modelos)
            .AsNoTracking()
            .FirstOrDefault(produto => produto.Id == id);
    }
}
