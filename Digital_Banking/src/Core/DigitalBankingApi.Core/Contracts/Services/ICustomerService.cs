﻿using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;
namespace DigitalBankingApi.Core.Contracts.Services;


public  interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetCustomer();
    Task<Customer> GetCustomertById(int id);
    Task<Customer> GetCustomerByIdProof(string idProof);
    Task<Customer> GetCustomerByName(string name);
    Task<bool> AddCustomer(Customer customer);
    Task<bool> UpdateEmployee(UpdateDto details, int id);
    Task<bool> HardDeleteEmployee(int id);
}