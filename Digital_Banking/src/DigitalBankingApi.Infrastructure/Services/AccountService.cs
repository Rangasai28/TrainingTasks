using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<bool> CreateAccount(AccountDetailsDto accountdetails)
    {
        var account = new Account
        {
            AccountNumber = GenerateAccountNumber(),
            Balance = accountdetails.Balance,
            AccountType = accountdetails.AccountType,
            BankName = accountdetails.BankName,
            BranchCode = accountdetails.BranchCode,
            CustomerId = accountdetails.CustomerId
        };
        return await _accountRepository.CreateAccount(account);
    }
    private static long GenerateAccountNumber()
    {
        var guid = Guid.NewGuid();
        var bytes = guid.ToByteArray();
        long accountNumber = BitConverter.ToInt64(bytes, 0);
        accountNumber = Math.Abs(accountNumber);

        return accountNumber;
    }
}
