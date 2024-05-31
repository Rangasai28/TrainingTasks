using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DigitalBankingApi.Infrastructure.Services;

public  class AuthenticateService:IAuthenticateService
{
    private const int SaltSize = 16; // 128 bit
    private const int KeySize = 32; // 256 bit
    private const int Iterations = 10000;
    private readonly IConfiguration configuration;

    public AuthenticateService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string GenerateSalt()
    {
        var saltBytes = new byte[SaltSize];
        using (var rng = new RNGCryptoServiceProvider())
        {

            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }

    public string GenerateToken(UserDto user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["JWTToken:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Email, user.Email),
                   // new Claim(ClaimTypes.Role, person.Role)
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        string userToken = tokenHandler.WriteToken(token);
        return userToken;
    }

    public string HashPassword(string password, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, Iterations))
        {
            var key = rfc2898DeriveBytes.GetBytes(KeySize);
            return Convert.ToBase64String(key);
        }
    }

    public bool VerifyPassword(string password, string salt, string hash)
    {
        var hashToVerify = HashPassword(password, salt);
        return hash == hashToVerify;
    }
}
