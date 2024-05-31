using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBankingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        //[HttpGet]
        //[Route("createbank")]

        //public async Task<ActionResult> CreateBank(Bank bank)
        //{
        //}
    }
}
