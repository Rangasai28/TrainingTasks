using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Services;

public  interface IBankService
{
    Task<IEnumerable<Bank>> GetBanks();
    Task<Bank> GetBankById(int id);
    Task<bool> CreateBank(Bank bank);
    Task<bool> UpdateBank(UpdateDto bankDetails, int id);

    Task<bool> HardDeleteBank(int id);
}
