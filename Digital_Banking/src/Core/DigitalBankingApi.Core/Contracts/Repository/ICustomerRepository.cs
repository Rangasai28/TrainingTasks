using DigitalBankingApi.Core.Models;

namespace DigitalBankingApi.Core.Contracts.Repository;



public  interface ICustomerRepository
{

    //Task<IEnumerable<CustomerDtoGet>> GetCustomer();
    //Task<CustomerDtoGet> GetCustomertById(int id);
    Task<bool> AddCustomer(Customer customer);

    //Task<bool> UpdateStudentEF(CustomerVm customerVm, int id);
    //Task<bool> HardDeleteStudentEF(int id);
    //Task<bool> SoftDeleteStudentEF(int id);

    //Task<bool> ValidateCustomer(string email, string password);
 
}
