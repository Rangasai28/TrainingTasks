namespace DigitalBankingApi.ViewModels;

public class BranchVm
{
    public string BranchName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Manager { get; set; } = null!;

    public string BranchCode { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public int BankId { get; set; }
}
