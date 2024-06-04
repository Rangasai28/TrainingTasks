namespace DigitalBankingApi.Core.Dtos;

public  class AccountDetailsDto
{
    public decimal Balance { get; set; }

    public string AccountType { get; set; } = null!;

    public string BankName { get; set; } = null!;

    public string BranchCode { get; set; } = null!;

    public int CustomerId { get; set; }

}
