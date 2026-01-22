
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Services.DataTypes;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace TestApp.Infrastructure.Repository;


public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
    : base(options)
    {
        
    }
    
    public DbSet<User> UserList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}