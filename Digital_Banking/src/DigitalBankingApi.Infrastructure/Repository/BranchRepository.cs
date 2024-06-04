using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.Infrastructure.Data;

namespace DigitalBankingApi.Infrastructure.Repository;

public  class BranchRepository:IBranchRepository
{
    private readonly DigitalBankingDbContext _branchContext;
    public BranchRepository(DigitalBankingDbContext repository)
    {
        _branchContext = repository;
    }
    public async Task<bool> CreateBranch(Branch branch)
    {
        if(_branchContext.Banks.Any(b=>b.BankId == branch.BankId))
        {
            _branchContext.Branches.Add(branch);
            int rowsEffected = await _branchContext.SaveChangesAsync();
            return rowsEffected > 0;
        }
        return false;
        
    }
}
