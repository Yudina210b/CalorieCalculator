using Domain.ValueObjects.Base;
using Domain.ValueObjects.Validators;

namespace Domain.ValueObjects
{
    public sealed class Age : ValueObject<int>
    {
        public Age(int value) : base(new AgeValidator(), value) { }
    }
}