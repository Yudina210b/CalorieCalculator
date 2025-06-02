using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects.Validators
{
    public class QuantityValidator : IValidator<decimal>
    {
        public static decimal MinValue => 1m;
        public static decimal MaxValue => 10000m;

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