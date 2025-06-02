using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.UserId).IsRequired();
            builder.Property(m => m.Date).IsRequired();
            builder.Property(m => m.Type).IsRequired();

            builder.HasMany<MealItem>()
                .WithOne()
                .HasForeignKey(mi => mi.MealId);
        }
    }
}