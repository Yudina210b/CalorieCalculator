using Domain.ValueObjects.Base;
using Domain.ValueObjects.Validators;

namespace Domain.ValueObjects
{
    public sealed class Weight : ValueObject<decimal>
    {
        public Weight(decimal value) : base(new WeightValidator(), value) { }
    }
}