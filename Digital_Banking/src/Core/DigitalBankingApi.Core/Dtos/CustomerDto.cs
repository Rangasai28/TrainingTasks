namespace DigitalBankingApi.Core.Dtos;

public  class CustomerDto
{
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public char Gender { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public long AccountNumber { get; set; }

    public string BranchName { get; set; } = null!;

    public string BankName { get; set; } = null!;
}
