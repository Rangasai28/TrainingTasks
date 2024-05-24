using Microsoft.EntityFrameworkCore;
using StudentWebApiEF.Core.Contracts;
using StudentWebApiEF.Infrastructure.Contexts;
using StudentWebApiEF.Infrastructure.Repositories;
using StudentWebApiEF.Infrastructure.Services;

namespace StudentWebApiEF;

public static  class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<StudentContext>(opt => opt.UseSqlServer(
         builder.Configuration.GetConnectionString("cs")));
        builder.Services.AddScoped<IStudentService, StudentService>();
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
