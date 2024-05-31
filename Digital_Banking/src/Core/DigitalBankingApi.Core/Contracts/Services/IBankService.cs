using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Services;

public  interface IBankService
{
    Task<bool> CreateBank(Bank bank);
}
