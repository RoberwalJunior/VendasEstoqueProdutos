namespace VendasEstoqueProdutos.Shared.Domain.Interfaces.Services;

public interface ITokenService
{
    public string GenerateToken(string email);
}
