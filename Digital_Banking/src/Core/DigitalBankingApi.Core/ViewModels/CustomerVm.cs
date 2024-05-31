namespace DigitalBankingApi.Core.ViewModels;

public  class CustomerVm
{
    public string ContactNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }
}
