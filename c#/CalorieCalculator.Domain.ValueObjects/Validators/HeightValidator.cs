using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects.Validators
{
    public class HeightValidator : IValidator<decimal>
    {
        public static decimal MinValue => 30m;
        public static decimal MaxValue => 300m;

        public void Validate(decimal value)
        {
            if (value <= 0)
                throw new NonPositiveValueException(nameof(value),
                    ExceptionMessages.NON_POSITIVE_VALUE);

            if (value > MaxValue)
                throw new TooHighValueException(nameof(value), value, MaxValue);
        }
    }
}