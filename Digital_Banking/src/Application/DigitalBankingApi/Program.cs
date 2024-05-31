using DigitalBankingApi.Configurations;
using DigitalBankingApi.Core.Contracts.Repository;
using DigitalBankingApi.Core.Contracts.Services;
using DigitalBankingApi.Infrastructure.Data;
using DigitalBankingApi.Infrastructure.Repository;
using DigitalBankingApi.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace DigitalBankingApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<DigitalBankingDbContext>(opt => opt.UseSqlServer(
builder.Configuration.GetConnectionString("cs")));
        builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        var mapper = AutoMapperConfiguration.IntializeMapper();
        builder.Services.AddSingleton(mapper);
        builder.Services.AddScoped<IBankRepository, BankRepository>();
        builder.Services.AddScoped<IBankService, BankService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
