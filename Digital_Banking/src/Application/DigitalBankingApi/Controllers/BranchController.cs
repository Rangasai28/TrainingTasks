using AutoMapper;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Dtos;
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

    [HttpGet]

    public async Task<ActionResult<IEnumerable<BranchDisplayDto>>> GetBanks()
    {
        var branches = await _branchService.GetBranches();
        if (!branches.Any())
        {
            return NoContent();
        }
        return Ok(branches);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BranchDisplayDto>> GetBranchById(int id)
    {
        var branch = await _branchService.GetBranchById(id);
        if (branch == null)
        {
            return NoContent();
        }
        return Ok(branch);
    }

    [HttpGet("name")]
    public async Task<ActionResult<BranchDisplayDto>> GetBranchByName(string name)
    {
        var branch = await _branchService.GetBranchByName(name);
        if (branch == null)
        {
            return NoContent();
        }
        return Ok(branch);
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

    [HttpPut]
    public async Task<ActionResult> UpdateBranch(CustomerVm branchdetails, int id)
    {
        var detailsFromUser = new UpdateDto
        {
            ContactNumber = branchdetails.ContactNumber,
            Address = branchdetails.Address,
        };
        if (await _branchService.UpdateBranch(detailsFromUser, id))
        {
            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("harddelete")]
    public async Task<ActionResult> HardDeleteBranch(int id)
    {
        if (await _branchService.HardDeleteBranch(id))
        {
            return NoContent();
        }
        return NotFound();
    }


}
