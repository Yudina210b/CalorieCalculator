using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations
{
    public class MealItemConfiguration : IEntityTypeConfiguration<MealItem>
    {
        public void Configure(EntityTypeBuilder<MealItem> builder)
        {
            builder.HasKey(mi => mi.Id);
            builder.Property(mi => mi.MealId).IsRequired();
            builder.Property(mi => mi.ProductId).IsRequired();
            builder.Property(mi => mi.Quantity).IsRequired().HasPrecision(7, 2);

            builder.HasOne<FoodProduct>()
                .WithMany()
                .HasForeignKey(mi => mi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}