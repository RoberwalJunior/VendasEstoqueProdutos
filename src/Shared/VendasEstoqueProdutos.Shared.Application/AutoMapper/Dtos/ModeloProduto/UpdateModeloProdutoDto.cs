using System.ComponentModel.DataAnnotations;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.ModeloProduto;

public class UpdateModeloProdutoDto
{
    [Required(ErrorMessage = "Descrição do modelo é obrigatório!")]
    [StringLength(255, ErrorMessage = "Descrição do modelo não pode ter mais de 255 caracteres!")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "Quantidade de estoque do modelo é obrigatório!")]
    public int QuantidadeEstoque { get; set; }
}
