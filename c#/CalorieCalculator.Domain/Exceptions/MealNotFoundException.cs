namespace Domain.Exceptions
{
    public class MealNotFoundException : DomainException
    {
        public MealNotFoundException(Guid mealId)
            : base($"Meal with ID {mealId} not found.")
        {
        }
    }
}