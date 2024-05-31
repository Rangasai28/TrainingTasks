using Microsoft.EntityFrameworkCore;
using  DigitalBankingApi.Core.Models;


namespace DigitalBankingApi.Infrastructure.Data;

public class DigitalBankingDbContext:DbContext
{
    public DigitalBankingDbContext(DbContextOptions<DigitalBankingDbContext> options) : base(options) { }

    public DbSet<Customer>  Customers { get; set; }

    public DbSet<Bank> Banks { get; set; }

    public DbSet<Account> Accounts { get; set; }

    public DbSet<Branch> Branches { get; set; }
}
