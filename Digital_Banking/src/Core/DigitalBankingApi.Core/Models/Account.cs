using System.ComponentModel.DataAnnotations;

namespace DigitalBankingApi.Core.Models;

public  class Account
{
    [Key]
    public long AccountNumber { get; set; }

    public decimal Balance {  get; set; } 

    public string AccountType { get; set; } = null!;

    public string BankName { get; set; } = null!;   

    public string BranchCode { get; set; } = null!;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? UpdatedDate { get; set; }

    public int CustomerId { get; set; }

    public bool IsActive { get; set; } = true;
}
