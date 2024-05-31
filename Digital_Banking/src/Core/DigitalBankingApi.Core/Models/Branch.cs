using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DigitalBankingApi.Core.Models;

public class Branch
{
    [Key]
    public int BranchId { get; set; }

    public string BranchName { get; set; } = null!;

    public string Address { get; set; } = null!;    

    public string Manager { get; set; } = null!;    

    public string BranchCode { get; set; } = null!; 

    public string ContactNumber { get; set; } = null!;

    public int BankId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
