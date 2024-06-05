using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBankingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;   
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<AccountDisplayDto>>> GetAccountDetails()
    {
        var accounts = await _accountService.GetAccountDetails();
        if (!accounts.Any())
        {
            return NoContent();
        }
        return Ok(accounts);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<AccountDisplayDto>> GetAccountDetailsById(int id)
    {
        var account = await _accountService.GetAccountDetailsById(id);
        if (account == null)
        {
            return NoContent();
        }
        return Ok(account);
    }

    [HttpGet("name")]
    public async Task<ActionResult<AccountDisplayDto>> GetAccountDetailsByName(string name)
    {
        var account = await _accountService.GetAccountDetailsByName(name);
        if (account == null)
        {
            return NoContent();
        }
        return Ok(account);
    }

    [HttpPut("delete")]
    public async Task<ActionResult> DeActivateAccount(int id)
    {
        if (await _accountService.DeActivateAccount(id))
        {
            return NoContent();
        }
        return NotFound();
    }
}
