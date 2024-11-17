using Microsoft.EntityFrameworkCore;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Context;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories.Base;

namespace VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories;

public class EmpresaRepository(AppDbContext context)
    : BaseRepository<Empresa>(context), IEmpresaRepository
{
    public override Empresa? GetById(int id)
    {
        return _context.Empresas
            .Include(empresa => empresa.Produtos!)
            //.ThenInclude(produto => produto.Modelos)
            .Include(empresa => empresa.Clientes)
            .Include(empresa => empresa.Vendas)
            .AsNoTracking()
            .FirstOrDefault(empresa => empresa.Id == id);
    }
}
