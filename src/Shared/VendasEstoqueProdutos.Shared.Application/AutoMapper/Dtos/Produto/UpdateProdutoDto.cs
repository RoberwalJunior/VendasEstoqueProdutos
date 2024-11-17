using System.ComponentModel.DataAnnotations;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;

public class UpdateProdutoDto
{
    [Required(ErrorMessage = "O Código do produto é obrigatório!")]
    public int Codigo { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório!")]
    [StringLength(50, ErrorMessage = "O nome do produto não pode ter mais de 50 caracteres!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O valor unitário do produto é obrigatório!")]
    public double ValorUnitario { get; set; }
}
