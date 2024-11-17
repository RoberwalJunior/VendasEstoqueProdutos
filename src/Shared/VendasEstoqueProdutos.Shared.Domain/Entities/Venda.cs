using System.ComponentModel.DataAnnotations;
using VendasEstoqueProdutos.Shared.Domain.Entities.Enums;

namespace VendasEstoqueProdutos.Shared.Domain.Entities;

public class Venda
{
    public int Id { get; set; }

    [Required]
    public int EmpresaId { get; set; }
    public virtual Empresa? Empresa { get; set; }

    public int ClienteId { get; set; }

    [Required]
    public double ValorTotal { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataDaCompra { get; set; }

    [Required]
    public TipoPagamento TipoPagamento { get; set; }

    [Required]
    public StatusPagamento StatusPagamento { get; set; }

    public virtual ICollection<ItemVenda>? Itens { get; set; }
}
