using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async  Task<bool> AddCustomer(Customer customer)
    {
        var result = await  _customerRepository.AddCustomer(customer);
        return result;
    }

    public async Task<IEnumerable<CustomerDto>> GetCustomer()
    {
        return await _customerRepository.GetCustomer(); 
    }

    public async Task<Customer> GetCustomerByIdProof(string idProof)
    {
        return await _customerRepository.GetCustomerByIdProof(idProof);
    }

    public async Task<Customer> GetCustomerByName(string name)
    {
        return await _customerRepository.GetCustomerByName(name);
    }

    public async Task<Customer> GetCustomertById(int id)
    {
        return await _customerRepository.GetCustomertById(id);
    }

    public async Task<bool> HardDeleteEmployee(int id)
    {
       return await _customerRepository.HardDeleteEmployee(id);   
    }

    public async Task<bool> UpdateEmployee(UpdateDto details, int id)
    {
       return await _customerRepository.UpdateEmployee(details, id);
    }
}
