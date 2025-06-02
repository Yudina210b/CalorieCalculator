using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Age).IsRequired();
            builder.Property(u => u.Gender).IsRequired();
            builder.Property(u => u.Weight).IsRequired().HasPrecision(5, 2);
            builder.Property(u => u.Height).IsRequired().HasPrecision(5, 2);
            builder.Property(u => u.ActivityLevel).IsRequired();
        }
    }
}