using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
        await  _accountContext.Accounts.AddAsync(account);
        int rows = await _accountContext.SaveChangesAsync();
        return rows>0;
    }

    public async Task<bool> DeActivateAccount(int customerId)
    {
        if( !( _accountContext.Accounts?.Any(e => e.CustomerId == customerId)).GetValueOrDefault())
        {
            return false;
        }
        var account = await _accountContext.Accounts.Where(a=> a.CustomerId == customerId).FirstOrDefaultAsync();
        account.IsActive = false;
        account.UpdatedDate = DateTime.Now;
        _accountContext.Entry(account).State = EntityState.Modified;
        try
        {
            await _accountContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!(_accountContext.Accounts?.Any(e => e.CustomerId == customerId)).GetValueOrDefault())
            {
                return false;
            }
            else
            {
                throw;
            }

        }
    }

    public async Task<IEnumerable<AccountDisplayDto>> GetAccountDetails()
    {
        var accountdetails =   await (from account in _accountContext.Accounts
                                      join customer in _accountContext.Customers on account.CustomerId equals customer.CustomerId
                                      select new AccountDisplayDto
                                      {
                                          AccountNumber = account.AccountNumber,
                                          Balance = account.Balance,
                                          AccountType = account.AccountType,
                                          BankName = account.BankName,
                                          BranchCode = account.BranchCode,
                                          CustomerName = customer.FullName,
                                          IsActive = account.IsActive
                                      }).ToListAsync();

        return accountdetails;
    }

    public async Task<AccountDisplayDto> GetAccountDetailsById(int id)
    {
       var accountDetails = await (from account in _accountContext.Accounts
                                         join customer in _accountContext.Customers on account.CustomerId equals customer.CustomerId
                                   where customer.CustomerId == id
                                         select new AccountDisplayDto
                                         {
                                             AccountNumber = account.AccountNumber,
                                             Balance = account.Balance,
                                             AccountType = account.AccountType,
                                             BankName = account.BankName,
                                             BranchCode = account.BranchCode,
                                             CustomerName = customer.FullName,
                                             IsActive = account.IsActive
                                         }).FirstOrDefaultAsync();
        return accountDetails;
    }

    public async  Task<AccountDisplayDto> GetAccountDetailsByName(string name)
    {
        var accountDetails = await(from account in _accountContext.Accounts
                                   join customer in _accountContext.Customers on account.CustomerId equals customer.CustomerId
                                   where customer.FirstName == name
                                   select new AccountDisplayDto
                                   {
                                       AccountNumber = account.AccountNumber,
                                       Balance = account.Balance,
                                       AccountType = account.AccountType,
                                       BankName = account.BankName,
                                       BranchCode = account.BranchCode,
                                       CustomerName = customer.FullName,
                                       IsActive = account.IsActive
                                   }).FirstOrDefaultAsync();
        return accountDetails;
    }


}
