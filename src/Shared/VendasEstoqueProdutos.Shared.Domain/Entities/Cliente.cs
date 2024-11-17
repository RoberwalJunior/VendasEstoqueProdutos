using System.ComponentModel.DataAnnotations;

namespace VendasEstoqueProdutos.Shared.Domain.Entities;

public class Cliente
{
    public int Id { get; set; }

    [Required]
    public int EmpresaId { get; set; }
    public virtual Empresa? Empresa { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Nome { get; set; }

    [MaxLength(50)]
    public string? RazaoSocial { get; set; }

    [MaxLength(20)]
    public string? Cnpj { get; set; }
}
