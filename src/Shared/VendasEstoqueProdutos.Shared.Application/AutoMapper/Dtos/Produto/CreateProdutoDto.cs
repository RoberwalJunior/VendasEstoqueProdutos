using System.ComponentModel.DataAnnotations;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Produto;

public class CreateProdutoDto
{
    [Required(ErrorMessage = "Empresa é obrigatório")]
    public int EmpresaId { get; set; }

    [Required(ErrorMessage = "Código do produto é obrigatório")]
    public int Codigo { get; set; }

    [Required(ErrorMessage = "Nome do produto é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome do produto não pode ter mais de 50 caracteres!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Valor Unitário é obrigatório")]
    public double ValorUnitario { get; set; }
}
