using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Context;

namespace VendasEstoqueProdutos.Test.WebApplication;

public class VendasEstoqueProdutosApplicationFactory : WebApplicationFactory<Program>
{
    private readonly AppDbContext _context;

    public VendasEstoqueProdutosApplicationFactory()
    {
        var scope = Services.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    }

    public async Task<Empresa> RecuperarEmpresaExistente()
    {
        var empresaExistente = await _context.Empresas.FirstOrDefaultAsync();

        if (empresaExistente == null)
        {
            var novaEmpresa = new Empresa()
            {
                Nome = "Empresa de Teste"
            };

            await _context.Empresas.AddAsync(novaEmpresa);
            await _context.SaveChangesAsync();

            empresaExistente = novaEmpresa;
        }

        return empresaExistente;
    }
}
