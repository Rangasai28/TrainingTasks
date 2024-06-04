using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Services;

public  interface IAccountService
{
    Task<bool> CreateAccount(AccountDetailsDto accountdetails);
}
