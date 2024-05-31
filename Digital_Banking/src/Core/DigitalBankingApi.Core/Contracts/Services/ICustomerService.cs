using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.Core.ViewModels;
namespace DigitalBankingApi.Core.Contracts.Services;


public  interface ICustomerService
{
  

    
    Task<bool> AddCustomer(Customer customer);
   



}
