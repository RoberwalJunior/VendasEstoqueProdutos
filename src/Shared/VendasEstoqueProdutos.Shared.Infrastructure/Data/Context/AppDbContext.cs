using Microsoft.EntityFrameworkCore;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VendasEstoqueProdutos.Shared.Infrastructure.Data.Context;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<ModeloProduto> ModeloProdutos { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<ItemVenda> ItemVendas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ItemVenda>()
            .HasOne(item => item.ModeloProduto)
            .WithMany(modelo => modelo.Itens)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
