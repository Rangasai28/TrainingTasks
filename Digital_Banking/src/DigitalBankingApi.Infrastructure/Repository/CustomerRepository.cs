using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.Infrastructure.Data;

namespace DigitalBankingApi.Infrastructure.Repository;



public class CustomerRepository : ICustomerRepository
{
    readonly DigitalBankingDbContext _customerContext;

    public CustomerRepository(DigitalBankingDbContext context)
    {
        _customerContext = context;
    }

    public async Task<bool> AddCustomer(Customer customer)
    {
        _customerContext.Customers.Add(customer);
        int rowsEffected = await _customerContext.SaveChangesAsync();
        return rowsEffected>0;
    }


}


