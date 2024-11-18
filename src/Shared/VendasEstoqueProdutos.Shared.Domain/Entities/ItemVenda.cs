using System.ComponentModel.DataAnnotations;

namespace VendasEstoqueProdutos.Shared.Domain.Entities;

public class ItemVenda
{
    public int Id { get; set; }

    [Required]
    public int VendaId { get; set; }
    public virtual Venda? Venda { get; set; }

    [Required]
    public int ModeloProdutoId { get; set; }
    public virtual ModeloProduto? ModeloProduto { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [Required]
    public double Valor { get; set; }
}
