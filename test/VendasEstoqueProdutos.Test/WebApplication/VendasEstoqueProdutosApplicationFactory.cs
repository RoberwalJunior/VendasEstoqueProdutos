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

    public async Task<Produto> RecuperarProdutoExistente()
    {
        var produtoExistente = await _context.Produtos
            .Include(produto => produto.Empresa)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (produtoExistente == null)
        {
            var empresaExistente = await RecuperarEmpresaExistente();
            var novoProduto = new Produto()
            {
                EmpresaId = empresaExistente.Id,
                Codigo = 999,
                Nome = "Teste de produto",
                ValorUnitario = 100.99
            };

            await _context.Produtos.AddAsync(novoProduto);
            await _context.SaveChangesAsync();

            produtoExistente = novoProduto;
        }

        return produtoExistente;
    }

    public async Task<ModeloProduto> RecuperarModeloProdutoExistente()
    {
        var modeloProdutoExistente = await _context.ModeloProdutos
            .Include(produto => produto.Produto)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (modeloProdutoExistente == null)
        {
            var produtoExistente = await RecuperarProdutoExistente();
            var novoModeloProduto = new ModeloProduto()
            {
                ProdutoId = produtoExistente.Id,
                Descricao = "Teste modelo produto",
                QuantidadeEstoque = 50
            };

            await _context.ModeloProdutos.AddAsync(novoModeloProduto);
            await _context.SaveChangesAsync();

            modeloProdutoExistente = novoModeloProduto;
        }

        return modeloProdutoExistente;
    }

    public async Task<Cliente> RecuperarClienteExistente()
    {
        var clienteExistente = await _context.Clientes
            .Include(cliente => cliente.Empresa)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (clienteExistente == null)
        {
            var empresaExistente = await RecuperarEmpresaExistente();
            var novoCliente = new Cliente()
            {
                EmpresaId = empresaExistente.Id,
                Nome = "Cliente teste"
            };

            await _context.Clientes.AddAsync(novoCliente);
            await _context.SaveChangesAsync();

            clienteExistente = novoCliente;
        }

        return clienteExistente;
    }
}
