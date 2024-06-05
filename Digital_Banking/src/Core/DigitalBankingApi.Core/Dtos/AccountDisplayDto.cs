namespace DigitalBankingApi.Core.Dtos;

public  class AccountDisplayDto
{
    public long AccountNumber { get; set; }
    public decimal Balance { get; set; }

    public string AccountType { get; set; } = null!;

    public string BankName { get; set; } = null!;

    public string BranchCode { get; set; } = null!;

    public string CustomerName { get; set; } = null!;
    public bool IsActive { get; set; }
}
