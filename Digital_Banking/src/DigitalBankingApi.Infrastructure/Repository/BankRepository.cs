using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.Infrastructure.Data;

namespace DigitalBankingApi.Infrastructure.Repository;

public class BankRepository : IBankRepository
{ 
    private readonly DigitalBankingDbContext _bankRepository;
    public BankRepository(DigitalBankingDbContext repository)
    {
        _bankRepository = repository;
    }
    public async Task<bool> CreateBank(Bank bank)
    {
        _bankRepository.Banks.Add(bank);
        int rowsEffected = await _bankRepository.SaveChangesAsync();
        return rowsEffected > 0;
    }
}
