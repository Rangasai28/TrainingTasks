using System.ComponentModel.DataAnnotations;

namespace DigitalBankingApi.Core.Models;

public  class Transaction
{
    [Key]
    public string TransactionId { get; set; }

    public string TransactionType { get; set; } = null!;

    public decimal Amount { get; set; } 

    public long AccountNumber { get; set; }

    public DateTime TransactionDate { get; set; }
}
