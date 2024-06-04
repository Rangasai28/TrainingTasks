using AutoMapper;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBankingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IAuthenticateService _authenticateService;
    private readonly IAccountService _accountService;
    private readonly IMapper mapper;
    public CustomerController(ICustomerService customerService, IAuthenticateService authenticateService, IMapper mapper, IAccountService accountService)
    {
        _customerService = customerService;
        _authenticateService = authenticateService;
        this.mapper = mapper;
        _accountService = accountService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerDetails()
    {
        var customers = await _customerService.GetCustomer();
        if (!customers.Any())
        {
            return NoContent();
        }
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
    {
        var customer = await _customerService.GetCustomertById(id);
        if (customer == null)
        {
            return NoContent();
        }
        return Ok(customer);
    }

    [HttpGet("name")]
    public async Task<ActionResult<CustomerDto>> GetCustomerByName(string name)
    {
        var customer = await _customerService.GetCustomerByName(name);
        if (customer == null)
        {
            return NoContent();
        }
        return Ok(customer);
    }

    [AllowAnonymous]
    [HttpPost("registercustomer")]
    public async Task<ActionResult> Registration(RegistrationVm registrationDetails)
    {
        if (registrationDetails == null)
        {
            return BadRequest();
        }
        try
        {
             var salt = _authenticateService.GenerateSalt();
             registrationDetails.Password = _authenticateService.HashPassword(registrationDetails.Password,salt);
            var customer = mapper.Map<RegistrationVm, Customer>(registrationDetails);
            customer.Salt = salt;
            var result = await _customerService.AddCustomer(customer);
            var cust = await _customerService.GetCustomerByIdProof(customer.IdProof);
            if (result)
            {
                var accountDetail = new AccountDetailsDto
                {
                    Balance = 0,
                    AccountType = "Savings",
                    BankName = registrationDetails.BrankName,
                    BranchCode = registrationDetails.BranchCode,
                    CustomerId = cust.CustomerId
                };
                var status = await _accountService.CreateAccount(accountDetail);
                return Ok(status);
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new{Error = $"An error occurred:{ ex.Message}" });
        }
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult> CustomerLogin(LoginVm loginDetails)
    {
        if (loginDetails == null)
        {
            return BadRequest();
        }
        try
        {
             var customer = await _customerService.GetCustomerByName(loginDetails.LoginName);
            
            if (!_authenticateService.VerifyPassword(loginDetails.LoginPassword, customer.Salt, customer.Password))
            {
                return BadRequest("Invalid Details");
            }
           
            var token = _authenticateService.GenerateToken(new UserDto { Email = customer.Email });
            return Ok(token);
        }
        catch(Exception ex)
        {
            return BadRequest(new { Error = $"An error occurred:{ex.Message}" });
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateEmployee(CustomerVm details,int id)
    {
        var detailsFromUser = new UpdateDto
        {
            ContactNumber = details.ContactNumber,
            Address = details.Address,
        };
        if (await _customerService.UpdateEmployee(detailsFromUser, id))
        {
            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("harddelete")]
    public async Task<ActionResult> HardDeleteEmployee(int id)
    {
        if (await _customerService.HardDeleteEmployee(id))
        {
            return NoContent();
        }
        return NotFound();
    }

}
