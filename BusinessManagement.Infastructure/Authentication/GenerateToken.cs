using BusinessManagement.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BusinessManagement.Infrastructure.Authentication;

public class GenerateToken : IGenerateToken
{
    private readonly JwtOptions jwtOptions;

    public GenerateToken(IOptions<JwtOptions> jwtOptions)
    {
        this.jwtOptions = jwtOptions.Value;
    }

    public JwtSecurityToken GenerateAccessToken(Users user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimNames.Id, user.Id.ToString()),
            new Claim(ClaimNames.Role, user.Roles.ToString()),
            new Claim(ClaimNames.Email, user.Email)
        };

        var symmetricSecurityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(this.jwtOptions.SecretKey));

        var accessToken = new JwtSecurityToken(
            issuer: jwtOptions.Issuer,
            audience: jwtOptions.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(jwtOptions.ExpirationInMinutes),
            signingCredentials: new SigningCredentials(
                key: symmetricSecurityKey,
                algorithm: SecurityAlgorithms.HmacSha256));

        return accessToken;        
    }

    public string GenerateRefreshToken()
    {
        byte[] bytes = new byte[64];

        var randomGenerator = RandomNumberGenerator.Create();

        randomGenerator.GetBytes(bytes);

        return Convert.ToBase64String(bytes);
    }
}