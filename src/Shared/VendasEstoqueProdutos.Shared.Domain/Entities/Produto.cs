using System.ComponentModel.DataAnnotations;

namespace VendasEstoqueProdutos.Shared.Domain.Entities;

public class Produto
{
    public int Id { get; set; }

    [Required]
    public int EmpresaId { get; set; }
    public virtual Empresa? Empresa { get; set; }

    [Required]
    public int Codigo { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Nome { get; set; }

    [Required]
    public double ValorUnitario { get; set; }

    public virtual ICollection<ModeloProduto>? Modelos { get; set; }
}
