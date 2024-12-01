namespace VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.User;

public class UserTokenDto
{
    public string? Token { get; set; }
    public DateTime Expiration { get; set; }
}
