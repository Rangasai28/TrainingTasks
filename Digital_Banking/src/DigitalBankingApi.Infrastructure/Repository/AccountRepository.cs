using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.Infrastructure.Data;

namespace DigitalBankingApi.Infrastructure.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly DigitalBankingDbContext _accountContext;

    public AccountRepository(DigitalBankingDbContext accountContext)
    {
        _accountContext = accountContext;
    }
    public async  Task<bool> CreateAccount(Account account)
    {
        _accountContext.Accounts.Add(account);
        int rows = await _accountContext.SaveChangesAsync();
        return rows>0;
    }
}
