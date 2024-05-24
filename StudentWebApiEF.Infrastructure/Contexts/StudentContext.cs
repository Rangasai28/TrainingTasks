using Microsoft.EntityFrameworkCore;
using StudentWebApiEF.Core.Models;

namespace StudentWebApiEF.Infrastructure.Contexts;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> contextOptions) : base(contextOptions)
    { }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Student> Students { get; set; }
}
