using Microsoft.EntityFrameworkCore;
using TestApp.Infrastructure.Data;
namespace TestApp.Infrastructure.Repository;

public class EmployeeDbContext : DbContext
{
    public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
    public DbSet<EmployeeGovId> EmployeeGovId { get; set; }
    public DbSet<EmployeeWorkInfo> EmployeeWorkInfo { get; set; }
    
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) 
        : base(options)
    {
        
    }
    
}