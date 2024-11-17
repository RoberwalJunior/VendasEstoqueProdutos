using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Context;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories.Base;

namespace VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories;

public class ClienteRepository(AppDbContext context)
    : BaseRepository<Cliente>(context), IClienteRepository
{
}
