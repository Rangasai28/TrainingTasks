using System.ComponentModel.DataAnnotations;

namespace DigitalBankingApi.Core.Models;

public  class Bank
{
    [Key]
    public int BankId { get; set; }

    public string BankName { get; set; } = null!;

    public string Manager { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;  
    public string WebsiteUrl { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set;}

}
