using BusinessManagement.Application.EntitiesDto.AuthenticationDtos;

namespace BusinessManagement.Application.Services;

public interface IAuthenticationService
{
    ValueTask<TokenDto> LoginAsync(LoginDto loginDto);

    ValueTask<TokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
}
