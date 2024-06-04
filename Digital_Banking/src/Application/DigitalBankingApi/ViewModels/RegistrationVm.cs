namespace DigitalBankingApi.ViewModels;

public class RegistrationVm
{
    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string FullName { get; set; } = null!;
    public string IdProof { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public char Gender { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string BrankName { get; set; } = null!;

    public string BranchCode { get; set; } = null!;
}
