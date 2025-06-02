using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations
{
    public class FoodProductConfiguration : IEntityTypeConfiguration<FoodProduct>
    {
        public void Configure(EntityTypeBuilder<FoodProduct> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.CaloriesPer100g).IsRequired().HasPrecision(6, 2);
            builder.Property(p => p.ProteinsPer100g).IsRequired().HasPrecision(5, 2);
            builder.Property(p => p.FatsPer100g).IsRequired().HasPrecision(5, 2);
            builder.Property(p => p.CarbohydratesPer100g).IsRequired().HasPrecision(5, 2);
        }
    }
}