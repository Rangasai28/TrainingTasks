using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Repository;

public  interface IBankRepository
{
    Task<bool> CreateBank(Bank bank);
}
