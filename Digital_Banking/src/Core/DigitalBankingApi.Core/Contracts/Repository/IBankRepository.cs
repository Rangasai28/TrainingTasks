using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Repository;

public  interface IBankRepository
{
    Task<IEnumerable<Bank>> GetBanks();
    Task<Bank> GetBankById(int id);
    Task<bool> CreateBank(Bank bank);
    Task<bool> UpdateBank(UpdateDto bankDetails, int id);

    Task<bool> HardDeleteBank(int id);

    bool BankExists(int id);

}
