using AutoMapper;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBankingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IAuthenticateService _authenticateService;
    private readonly IMapper mapper;
    public CustomerController(ICustomerService customerService, IAuthenticateService authenticateService, IMapper mapper)
    {
        _customerService = customerService;
        _authenticateService = authenticateService;
        this.mapper = mapper;
    }


    [HttpPost("registercustomer")]
    public async Task<ActionResult> Registration(RegistrationVm customerDetails)
    {
        if (customerDetails == null)
        {
            return BadRequest();
        }
        try
        {
             var salt = _authenticateService.GenerateSalt();
             customerDetails.Password = _authenticateService.HashPassword(customerDetails.Password,salt);
            var customer = mapper.Map<RegistrationVm, Customer>(customerDetails);
            customer.Salt = salt;
            var result = await _customerService.AddCustomer(customer);

            var account = new Account
            {

            };
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new{Error = $"An error occurred:{ ex.Message}" });
        }
    }

}
