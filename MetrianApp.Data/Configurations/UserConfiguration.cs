using MetrianApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetrianApp.Data.Configurations
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder
          .HasKey(user => user.Id);

      builder
          .Property(user => user.Id)
          .UseMySqlIdentityColumn();

      builder
          .Property(user => user.FirstName)
          .IsRequired()
          .HasMaxLength(50);

      builder
          .ToTable("Users");
    }
  }
}