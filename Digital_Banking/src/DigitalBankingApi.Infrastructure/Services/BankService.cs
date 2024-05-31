using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Infrastructure.Services;

public class BankService : IBankService
{
    private readonly IBankRepository _bankRepository; 

    public BankService(IBankRepository bankRepository)
    {
        _bankRepository = bankRepository;
    }

    public Task<bool> CreateBank(Bank bank)
    {
      return _bankRepository.CreateBank(bank);
    }
}
