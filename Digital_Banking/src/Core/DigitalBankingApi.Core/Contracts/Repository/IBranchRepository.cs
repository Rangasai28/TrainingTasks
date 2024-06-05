using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Repository;

public  interface IBranchRepository
{
    Task<bool> CreateBranch(Branch branch);
    Task<IEnumerable<BranchDisplayDto>> GetBranches();

    Task<BranchDisplayDto> GetBranchById(int id);
    

    Task<BranchDisplayDto> GetBranchByName(string name);
  

    Task<bool> UpdateBranch(UpdateDto details, int id);
    Task<bool> HardDeleteBranch(int id);

    bool BranchExists(int id);
}
