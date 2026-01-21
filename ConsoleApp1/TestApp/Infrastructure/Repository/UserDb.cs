using System.Data.Common;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;
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