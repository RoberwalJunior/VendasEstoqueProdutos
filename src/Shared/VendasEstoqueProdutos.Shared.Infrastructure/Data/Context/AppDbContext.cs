using Microsoft.EntityFrameworkCore;
using VendasEstoqueProdutos.Shared.Domain.Entities;

namespace VendasEstoqueProdutos.Shared.Infrastructure.Data.Context;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<ModeloProduto> ModeloProdutos { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<ItemVenda> ItemVendas { get; set; }
}
