using System.ComponentModel.DataAnnotations;

namespace VendasEstoqueProdutos.Shared.Domain.Entities;

public class ModeloProduto
{
    public int Id { get; set; }

    [Required]
    public int ProdutoId { get; set; }
    public virtual Produto? Produto { get; set; }

    [Required]
    [MaxLength(255)]
    public string? Descricao { get; set; }

    [Required]
    public int QuantidadeEstoque { get; set; }
}
