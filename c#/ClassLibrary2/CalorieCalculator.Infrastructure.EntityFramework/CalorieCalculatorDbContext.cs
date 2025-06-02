using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class CalorieCalculatorDbContext : DbContext
    {
        public CalorieCalculatorDbContext(DbContextOptions<CalorieCalculatorDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<FoodProduct> FoodProducts => Set<FoodProduct>();
        public DbSet<Meal> Meals => Set<Meal>();
        public DbSet<MealItem> MealItems => Set<MealItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация для User
            modelBuilder.Entity<User>(u =>
            {
                u.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            // Конфигурация для FoodProduct
            modelBuilder.Entity<FoodProduct>(f =>
            {
                f.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                f.Property(x => x.CaloriesPer100g)
                    .HasPrecision(6, 2);

                f.Property(x => x.ProteinsPer100g)
                    .HasPrecision(5, 2);

                f.Property(x => x.FatsPer100g)
                    .HasPrecision(5, 2);

                f.Property(x => x.CarbohydratesPer100g)
                    .HasPrecision(5, 2);
            });

            // Конфигурация для Meal
            modelBuilder.Entity<Meal>(m =>
            {
                m.HasMany<MealItem>()
                    .WithOne()
                    .HasForeignKey(mi => mi.MealId);
            });

            // Конфигурация для MealItem
            modelBuilder.Entity<MealItem>(mi =>
            {
                mi.Property(x => x.Quantity)
                    .HasPrecision(7, 2);

                mi.HasOne<FoodProduct>()
                    .WithMany()
                    .HasForeignKey(mi => mi.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}