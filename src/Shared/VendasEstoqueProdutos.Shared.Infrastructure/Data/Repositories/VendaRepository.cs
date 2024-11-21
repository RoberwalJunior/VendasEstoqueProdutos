using Microsoft.EntityFrameworkCore;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Context;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories.Base;

namespace VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories;

public class VendaRepository(AppDbContext context)
    : BaseRepository<Venda>(context), IVendaRepository
{
    public override Venda? GetById(int id)
    {
        return _context.Vendas
            .Include(venda => venda.Empresa)
            .Include(venda => venda.Cliente)
            .Include(venda => venda.Itens)
            .AsNoTracking()
            .FirstOrDefault(venda => venda.Id == id);
    }
}
