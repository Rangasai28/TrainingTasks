using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Repository;

public interface IAccountRepository
{
    Task<bool> CreateAccount(Account account);
}
