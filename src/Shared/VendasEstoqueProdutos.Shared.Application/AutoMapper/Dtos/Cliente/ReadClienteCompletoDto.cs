using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Empresa;

namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.Cliente;

public class ReadClienteCompletoDto
{
    public string? Nome { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; set; }
    public ReadEmpresaDto? Empresa { get; set; }
}
