using VendasEstoqueProdutos.Shared.Application.Interfaces;
using VendasEstoqueProdutos.Shared.Application.AutoMapper.Dtos.User;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Services;

namespace VendasEstoqueProdutos.Shared.Application.ServiceApp;

public class UserServiceApp(IUserService userService, ITokenService tokenService) : IUserServiceApp
{
    private readonly IUserService _userService = userService;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<bool> RegistrarUsuario(UserInfoDto userDto)
    {
        return await _userService.RegisterUser(userDto.Email!, userDto.Senha!);
    }

    public async Task<UserTokenDto?> Login(UserInfoDto userDto)
    {
        var result = await _userService.Login(userDto.Email!, userDto.Senha!);
        return result ? BuildToken(userDto) : null;
    }

    private UserTokenDto BuildToken(UserInfoDto userInfo)
    {
        return new UserTokenDto()
        {
            Token = _tokenService.GenerateToken(userInfo.Email!),
            Expiration = DateTime.UtcNow.AddHours(2)
        };
    }
}
