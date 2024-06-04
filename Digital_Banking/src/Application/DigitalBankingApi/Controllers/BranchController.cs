using AutoMapper;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBankingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BranchController : ControllerBase
{
    private readonly IBranchService _branchService;
    private readonly IMapper mapper;
    public BranchController(IBranchService bankService, IMapper mapper)
    {
        _branchService = bankService;
        this.mapper = mapper;
    }

    [HttpPost]
    [Route("createbranch")]

    public async Task<ActionResult> CreateBranch(BranchVm branchDetails)
    {
        var branch = mapper.Map<BranchVm, Branch>(branchDetails);
        branch.CreatedDate = DateTime.Now;
        var result = await _branchService.CreateBranch(branch);
        return Ok(result);
    }
}
