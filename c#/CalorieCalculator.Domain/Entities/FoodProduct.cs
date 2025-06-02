using Domain.Entities.Base;
using Domain.ValueObjects;
using System;

namespace Domain.Entities
{
    public class FoodProduct : Entity<Guid>
    {
        public string Name { get; }
        public decimal CaloriesPer100g { get; }
        public decimal ProteinsPer100g { get; }
        public decimal FatsPer100g { get; }
        public decimal CarbohydratesPer100g { get; }

        public FoodProduct(
            Guid id,
            string name,
            decimal caloriesPer100g,
            decimal proteinsPer100g,
            decimal fatsPer100g,
            decimal carbohydratesPer100g)
            : base(id)
        {
            ValidateInputs(name, caloriesPer100g, proteinsPer100g, fatsPer100g, carbohydratesPer100g);

            Name = name;
            CaloriesPer100g = caloriesPer100g;
            ProteinsPer100g = proteinsPer100g;
            FatsPer100g = fatsPer100g;
            CarbohydratesPer100g = carbohydratesPer100g;
        }

        private void ValidateInputs(
            string name,
            decimal calories,
            decimal proteins,
            decimal fats,
            decimal carbs)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty or whitespace", nameof(name));

            if (name.Length > 100)
                throw new ArgumentException("Product name cannot exceed 100 characters", nameof(name));

            if (calories < 0 || proteins < 0 || fats < 0 || carbs < 0)
                throw new ArgumentException("Nutrition values cannot be negative");

            if (calories > 1000)
                throw new ArgumentException("Calories value is unrealistically high", nameof(calories));
        }

        // Для EF Core
        protected FoodProduct() : base(Guid.NewGuid()) { }
    }
}