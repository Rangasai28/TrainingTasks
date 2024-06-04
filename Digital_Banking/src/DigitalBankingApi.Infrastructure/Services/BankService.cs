using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Dtos;
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

    public Task<Bank> GetBankById(int id)
    {
       return _bankRepository.GetBankById(id);
    }

    public Task<IEnumerable<Bank>> GetBanks()
    {
        return _bankRepository.GetBanks();
    }

    public async Task<bool> HardDeleteBank(int id)
    {
        if(!_bankRepository.BankExists(id))
        {
            return false;
        }
        return await _bankRepository.HardDeleteBank(id);
    }

    public async Task<bool> UpdateBank(UpdateDto bankDetails, int id)
    {
        if (!_bankRepository.BankExists(id))
        {
            return false;
        }
        return await _bankRepository.UpdateBank(bankDetails,id);
    }
}
