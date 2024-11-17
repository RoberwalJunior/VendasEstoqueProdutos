using System.ComponentModel.DataAnnotations;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;

public class UpdateClienteDto
{
    [Required(ErrorMessage = "Nome do cliente é obrigatório!")]
    [StringLength(50, ErrorMessage = "Nome do cliente não pode ter mais de 50 caracteres!")]
    public string? Nome { get; set; }

    [StringLength(50, ErrorMessage = "Razão Social não pode ter mais de 50 caracteres!")]
    public string? RazaoSocial { get; set; }

    [StringLength(20, ErrorMessage = "CNPJ do cliente não pode ter mais de 20 caracteres!")]
    public string? Cnpj { get; set; }
}
