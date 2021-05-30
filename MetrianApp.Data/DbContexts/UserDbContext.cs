using Microsoft.EntityFrameworkCore;
using MetrianApp.Core.Models;
using MetrianApp.Data.Configurations;

namespace MetrianApp.Data.DbContexts
{
  public class UserDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder
          .ApplyConfiguration(new UserConfiguration());
    }
  }
}