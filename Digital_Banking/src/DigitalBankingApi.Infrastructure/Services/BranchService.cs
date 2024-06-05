using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.Infrastructure.Repository;

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

    public async Task<IEnumerable<BranchDisplayDto>> GetBranches()
    {
       return await _branchRepository.GetBranches();
    }

    public async Task<BranchDisplayDto> GetBranchById(int id)
    {
        return await _branchRepository.GetBranchById(id);
    }

    public async Task<bool> HardDeleteBranch(int id)
    {
        return await _branchRepository.HardDeleteBranch(id);
    }

    public async Task<bool> UpdateBranch(UpdateDto branchDetails, int id)
    {
        if (!_branchRepository.BranchExists(id))
        {
            return false;
        }
        return await _branchRepository.UpdateBranch(branchDetails, id);
    }

    public async Task<BranchDisplayDto> GetBranchByName(string name)
    {
        return await _branchRepository.GetBranchByName(name);
    }
}
