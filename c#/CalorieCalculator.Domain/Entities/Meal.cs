using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities
{
    public class Meal : Entity<Guid>
    {
        public Guid UserId { get; protected set; }
        public DateTime Date { get; protected set; }
        public MealType Type { get; protected set; }

        protected Meal() : base(Guid.NewGuid()) { }

        public Meal(Guid id, Guid userId, DateTime date, MealType type) : base(id)
        {
            UserId = userId;
            Date = date;
            Type = type;
        }
    }

    public class MealItem : Entity<Guid>
    {
        public Guid MealId { get; protected set; }
        public Guid ProductId { get; protected set; }
        public decimal Quantity { get; protected set; }

        protected MealItem() : base(Guid.NewGuid()) { }

        public MealItem(Guid id, Guid mealId, Guid productId, decimal quantity) : base(id)
        {
            MealId = mealId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}