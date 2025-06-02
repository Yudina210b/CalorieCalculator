using Domain.ValueObjects.Base;
using Domain.ValueObjects.Validators;

namespace Domain.ValueObjects
{
    public sealed class Quantity : ValueObject<decimal>
    {
        public Quantity(decimal value) : base(new QuantityValidator(), value) { }
    }
}