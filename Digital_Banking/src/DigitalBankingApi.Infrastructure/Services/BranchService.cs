using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Infrastructure.Services;

public  class BranchService:IBranchService
{
    private readonly IBranchRepository _branchRepository;

    public BranchService(IBranchRepository bankRepository)
    {
        _branchRepository = bankRepository;
    }

    

    public async Task<bool> CreateBranch(Branch branch)
    {
        return await _branchRepository.CreateBranch(branch);
    }
}
