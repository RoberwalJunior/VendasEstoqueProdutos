using System.ComponentModel.DataAnnotations;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;

public class CreateModeloProdutoDto
{
    [Required(ErrorMessage = "Produto é obrigatório")]
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "Descrição é obrigatório")]
    [StringLength(255, ErrorMessage = "O nome do produto não pode ter mais de 255 caracteres!")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "Quantidade de estoque é obrigatório")]
    public int QuantidadeEstoque { get; set; }
}
