using Domain.ValueObjects.Base;
using Domain.ValueObjects.Validators;

namespace Domain.ValueObjects
{
    public sealed class Height : ValueObject<decimal>
    {
        public Height(decimal value) : base(new HeightValidator(), value) { }
    }
}