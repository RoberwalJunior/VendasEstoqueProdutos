namespace VendasEstoqueProdutos.Shared.Domain.Interfaces.Services;

public interface IUserService
{
    public Task<bool> RegisterUser(string email, string password);
    public Task<bool> Login(string email, string password);
}
