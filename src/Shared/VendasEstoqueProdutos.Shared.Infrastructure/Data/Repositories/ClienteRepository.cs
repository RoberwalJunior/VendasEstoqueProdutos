using Microsoft.EntityFrameworkCore;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Context;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories.Base;

namespace VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories;

public class ClienteRepository(AppDbContext context)
    : BaseRepository<Cliente>(context), IClienteRepository
{
    public override Cliente? GetById(int id)
    {
        return _context.Clientes
            .Include(cliente => cliente.Empresa)
            .AsNoTracking()
            .FirstOrDefault(cliente => cliente.Id == id);
    }
}
