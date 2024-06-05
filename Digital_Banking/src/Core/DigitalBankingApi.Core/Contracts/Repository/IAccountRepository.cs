using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Repository;

public interface IAccountRepository
{
    Task<bool> CreateAccount(Account account);

    Task<IEnumerable<AccountDisplayDto>> GetAccountDetails();

    Task<AccountDisplayDto> GetAccountDetailsById(int id);

    Task<AccountDisplayDto> GetAccountDetailsByName(string name);

    Task<bool> DeActivateAccount(int customerId);
}
