using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DigitalBankingApi.Infrastructure.Repository;

public class BankRepository : IBankRepository
{ 
    private readonly DigitalBankingDbContext _bankContext;
    public BankRepository(DigitalBankingDbContext repository)
    {
        _bankContext = repository;
    }
    public async Task<bool> CreateBank(Bank bank)
    {
        await _bankContext.Banks.AddAsync(bank);
        int rowsEffected = await _bankContext.SaveChangesAsync();
        return rowsEffected > 0;
    }

    

    public async  Task<Bank> GetBankById(int id)
    {
        var bank = await _bankContext.Banks.FirstOrDefaultAsync(b => b.BankId == id);
        return bank;
    }

    public async Task<IEnumerable<Bank>> GetBanks()
    {
        var banks = await (from b in _bankContext.Banks select b).ToListAsync();
        return banks;
    }

    public async Task<bool> HardDeleteBank(int id)
    {
        var bank = await (from e in _bankContext.Banks where e.BankId == id select e).FirstOrDefaultAsync();
        if (bank == null)
        {
            return false;
        }
        _bankContext.Banks.Remove(bank);
        await _bankContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateBank(UpdateDto bankDetails, int id)
    {
        var bank = await _bankContext.Banks.FindAsync(id);
        bank.Address = bankDetails.Address;
        bank.ContactNumber = bankDetails.ContactNumber;
        bank.UpdatedDate = DateTime.Now;
        _bankContext.Entry(bank).State = EntityState.Modified;
        try
        {
            await _bankContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BankExists(id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }
    }
    public bool BankExists(int id)
    {
        return (_bankContext.Banks?.Any(e => e.BankId == id)).GetValueOrDefault();
    }
}
