namespace DigitalBankingApi.Core.Models;
public  class Role
{
    public int Id { get; set; }

    public string Manager { get; set; } = null!;

    public string Customer { get; set; } = null!;
}
