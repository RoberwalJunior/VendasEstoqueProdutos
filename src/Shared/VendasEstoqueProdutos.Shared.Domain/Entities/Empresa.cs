using System.ComponentModel.DataAnnotations;

namespace VendasEstoqueProdutos.Shared.Domain.Entities;

public class Empresa
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Nome { get; set; }

    [MaxLength(50)]
    public string? RazaoSocial { get; set; }

    [MaxLength(20)]
    public string? Cnpj { get; set; }

    public virtual ICollection<Produto>? Produtos { get; set; }
    public virtual ICollection<Cliente>? Clientes { get; set; }
    public virtual ICollection<Venda>? Vendas { get; set; }
}
