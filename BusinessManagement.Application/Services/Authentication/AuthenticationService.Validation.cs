using BusinessManagement.Application.EntitiesDto.AuthenticationDtos;
using BusinessManagement.Domain.Entities;
using BusinessManagement.Domain.Exceptions;

namespace BusinessManagement.Application.Services;

public partial class AuthenticationService
{
    private void ValidateStorageUser(Users user)
    {
        if (user == null)
            throw new NotFoundException("Email yoki password xato");
    }
    private void ValidateStoragePassword(Users user, LoginDto loginDto)
    {
        if(!passwordHasher.VerifyPassword(
            password: loginDto.password,
            salt: user.Salt,
            hash: user.PasswordHash))
        {
            throw new NotFoundException("Email yoki password xato");
        }
    }
    private void ValidateRefreshToken(
        RefreshTokenDto refreshTokenDto, Users user)
    {
        if (!user.RefreshToken.Equals(refreshTokenDto.refreshToken))
            throw new InvalidRefreshTokenException("Refresh token yaroqsiz");
    }
    private void ValidateRefreshTokenExpiredDate(Users user)
    {
        if (user.ExpiredRefreshToken <= DateTime.Now)
            throw new InvalidRefreshTokenException("Refresh token muddati o'tib ketgan");
    }
    private void ValidateUser(Users user)
    {
        if(user is null)
        {
            throw new NotFoundException("Bu token yaroqsiz.");
        }
    }
}
