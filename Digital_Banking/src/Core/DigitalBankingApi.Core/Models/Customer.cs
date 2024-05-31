using System.ComponentModel.DataAnnotations;
namespace DigitalBankingApi.Core.Models;

public  class Customer
{
    [Key]
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string  Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public char Gender { get; set; } 

    public string ContactNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.Now;

    public DateTime? UpdateDate { get; set; } 
}
