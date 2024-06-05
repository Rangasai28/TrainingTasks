using AutoMapper;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBankingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankController : ControllerBase
{
    private readonly IBankService _bankService;
    private readonly IMapper mapper;
    public BankController(IBankService bankService, IMapper mapper)
    {
        _bankService = bankService;
        this.mapper = mapper;
    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<Bank>>> GetBanks()
    {
        var banks = await _bankService.GetBanks();
        if (!banks.Any())
        {
            return NoContent();
        }
        return Ok(banks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bank>> GetBankById(int id)
    {
        var bank = await _bankService.GetBankById(id);
        if (bank == null)
        {
            return NoContent();
        }
        return Ok(bank);
    }

    [HttpPost]
    [Route("createbank")]

    public async Task<ActionResult> CreateBank(BankVm bankDetails)
    {
        var bank = mapper.Map<BankVm, Bank>(bankDetails);
        bank.CreatedDate = DateTime.Now;
        var result = await _bankService.CreateBank(bank);
        return Ok(result);
    }


    [HttpPut]
    public async Task<ActionResult> UpdateBank(CustomerVm bankdetails, int id)
    {
        var detailsFromUser = new UpdateDto
        {
            ContactNumber = bankdetails.ContactNumber,
            Address = bankdetails.Address,
        };
        if (await _bankService.UpdateBank(detailsFromUser, id))
        {
            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("harddelete")]
    public async Task<ActionResult> HardDeleteBank(int id)
    {
        if (await _bankService.HardDeleteBank(id))
        {
            return NoContent();
        }
        return NotFound();
    }
}
