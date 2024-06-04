using DigitalBankingApi.Core.Dtos;

namespace DigitalBankingApi.Core.Contracts.Services;

public  interface IAuthenticateService
{
    string GenerateSalt();
    string HashPassword(string password, string salt);
    bool VerifyPassword(string password, string salt, string hash);
    string GenerateToken(UserDto userDto);
}
