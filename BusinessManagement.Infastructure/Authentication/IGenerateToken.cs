
using BusinessManagement.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace BusinessManagement.Infrastructure.Authentication;

public interface IGenerateToken
{
    JwtSecurityToken GenerateAccessToken(Users user);

    string GenerateRefreshToken();
}
