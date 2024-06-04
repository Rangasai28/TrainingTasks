using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Dtos;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
        return rowsEffected > 0;
    }

    public async Task<IEnumerable<CustomerDto>> GetCustomer()
    {
        var customerDetails = await _customerContext.Customers
             .Join(_customerContext.Accounts,
           customer => customer.CustomerId,
           account => account.CustomerId,
           (customer, account) => new CustomerDto
           {
               FullName = customer.FullName,
               Email = customer.Email,
               Gender = customer.Gender,
               ContactNumber = customer.ContactNumber,
               Address = customer.Address,
               AccountNumber = account.AccountNumber,
               BranchName = account.BranchCode
           }).ToListAsync();
        //.Join(_customerContext.Branches,
        //      combined => combined.account.BranchCode,
        //      branch=>branch.BranchCode,
        //      (combined, branch) => new CustomerDto
        //      {
        //          FullName = combined.customer.FullName,
        //          Email = combined.customer.Email,
        //          Gender = combined.customer.Gender,
        //          ContactNumber = combined.customer.ContactNumber,
        //          Address = combined.customer.Address,
        //          AccountNumber = combined.account.AccountNumber,
        //          BranchName = branch.BranchName,
        //          BankName = combined.account.BankName,

        //      }).ToListAsync();
        return customerDetails;
    }

    public async Task<Customer> GetCustomerByIdProof(string idProof)
    {
        var customer = await (from c in _customerContext.Customers where c.IdProof == idProof select c).FirstAsync();
        return customer;
    }

    public async Task<Customer> GetCustomerByName(string name)
    {
        var customer = await _customerContext.Customers.FirstOrDefaultAsync(c => c.FirstName == name);

        return customer;
    }

    public async Task<bool> HardDeleteEmployee(int id)
    {
        var customer = await (from e in _customerContext.Customers where e.CustomerId == id select e).FirstOrDefaultAsync();
        if (customer == null)
        {
            return false;
        }
        _customerContext.Customers.Remove(customer);
        await _customerContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateEmployee(UpdateDto details, int id)
    {
        var customer = await _customerContext.Customers.FindAsync(id);
        customer.Address = details.Address;
        customer.ContactNumber = details.ContactNumber;
        customer.UpdateDate = DateTime.Now;
        _customerContext.Entry(customer).State = EntityState.Modified;
        try
        {
            await _customerContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }
    }

     async Task<Customer> ICustomerRepository.GetCustomertById(int id)
    {
        var customer = await _customerContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        return customer;
    }

    public bool CustomerExists(int id)
    {
        return (_customerContext.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
    }
}


