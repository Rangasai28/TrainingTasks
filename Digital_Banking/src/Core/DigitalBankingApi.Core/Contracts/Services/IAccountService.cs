using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Services;

public  interface IAccountService
{
    Task<bool> CreateAccount(AccountDetailsDto accountdetails);
    Task<IEnumerable<AccountDisplayDto>> GetAccountDetails();

    Task<AccountDisplayDto> GetAccountDetailsById(int id);
    Task<AccountDisplayDto> GetAccountDetailsByName(string name);

    Task<bool> DeActivateAccount(int customerId);
}
