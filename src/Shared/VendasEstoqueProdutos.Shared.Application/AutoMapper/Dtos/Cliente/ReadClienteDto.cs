namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;

public class ReadClienteDto
{
    public int Id { get; set; }
    public int EmpresaId { get; set; }
    public string? Nome { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; set; }
}
