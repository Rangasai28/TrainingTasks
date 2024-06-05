using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DigitalBankingApi.Infrastructure.Repository;

public  class BranchRepository:IBranchRepository
{
    private readonly DigitalBankingDbContext _branchContext;
    public BranchRepository(DigitalBankingDbContext repository)
    {
        _branchContext = repository;
    }

    public bool BranchExists(int id)
    {
        return (_branchContext.Branches?.Any(e => e.BranchId == id)).GetValueOrDefault();
    }

    public async Task<bool> CreateBranch(Branch branch)
    {
        if(await _branchContext.Banks.AnyAsync(b=>b.BankId == branch.BankId))
        {
            await  _branchContext.Branches.AddAsync(branch);
            int rowsEffected = await _branchContext.SaveChangesAsync();
            return rowsEffected > 0;
        }
        return false;
        
    }

    public async Task<BranchDisplayDto> GetBranchById(int id)
    {
        var branch = await _branchContext.Branches.Where(c => c.BranchId == id).Select(c => new BranchDisplayDto
        {
            BranchName = c.BranchName,

            Address = c.Address,

            Manager = c.Manager,

            BranchCode = c.BranchCode,

            ContactNumber = c.ContactNumber,
        }).FirstOrDefaultAsync();
        return branch;
    }

    public async  Task<BranchDisplayDto> GetBranchByName(string name)
    {
        var branch = await _branchContext.Branches.Where(c => c.BranchName == name).Select(c => new BranchDisplayDto
        {
            BranchName = c.BranchName,

            Address = c.Address,

            Manager = c.Manager,

            BranchCode = c.BranchCode,

            ContactNumber = c.ContactNumber,
        }).FirstOrDefaultAsync();

        return branch;
    }

    public async Task<IEnumerable<BranchDisplayDto>> GetBranches()
    {
        var branches = await (from b in _branchContext.Branches
                              select  new BranchDisplayDto
        {
            BranchName = b.BranchName,

            Address = b.Address,

            Manager = b.Manager,

            BranchCode = b.BranchCode,

            ContactNumber = b.ContactNumber,
        }).ToListAsync();
        return branches;
    }

    public async Task<bool> HardDeleteBranch(int id)
    {
        if (!BranchExists(id))
        {
            return false;
        }
        var branch  = await (from e in _branchContext.Branches where e.BranchId == id select e).FirstOrDefaultAsync();
        _branchContext.Branches.Remove(branch);
        await _branchContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateBranch(UpdateDto details, int id)
    {
        var branch = await _branchContext.Branches.FindAsync(id);
        branch.Address = details.Address;
        branch.ContactNumber = details.ContactNumber;
        branch.UpdatedDate = DateTime.Now;
        _branchContext.Entry(branch).State = EntityState.Modified;
        try
        {
            await _branchContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BranchExists(id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }
    }
}
