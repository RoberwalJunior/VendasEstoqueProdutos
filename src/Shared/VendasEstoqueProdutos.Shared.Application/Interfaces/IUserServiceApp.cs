using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.User;

namespace VendasEstoqueProdutos.Shared.Application.Interfaces;

public interface IUserServiceApp
{
    public Task<bool> RegistrarUsuario(UserInfoDto userDto);
    public Task<UserTokenDto?> Login(UserInfoDto userDto);
}
