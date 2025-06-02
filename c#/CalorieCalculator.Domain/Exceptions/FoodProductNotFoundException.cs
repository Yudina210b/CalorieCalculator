namespace Domain.Exceptions
{
    public class FoodProductNotFoundException : DomainException
    {
        public FoodProductNotFoundException(Guid productId)
            : base($"Food product with ID {productId} not found.")
        {
        }
    }
}