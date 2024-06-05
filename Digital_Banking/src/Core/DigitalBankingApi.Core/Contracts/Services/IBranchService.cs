using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Services;

public  interface IBranchService
{
    Task<bool> CreateBranch(Branch branch);

    Task<IEnumerable<BranchDisplayDto>> GetBranches();
    Task<BranchDisplayDto> GetBranchById(int id);
    Task<BranchDisplayDto> GetBranchByName(string name);
    Task<bool> UpdateBranch(UpdateDto branchDetails, int id);

    Task<bool> HardDeleteBranch(int id);
}
