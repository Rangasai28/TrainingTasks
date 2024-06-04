using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Services;

public  interface IBranchService
{
    Task<bool> CreateBranch(Branch branch);
}
