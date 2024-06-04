using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Repository;

public  interface IBranchRepository
{
    Task<bool> CreateBranch(Branch branch);
}
