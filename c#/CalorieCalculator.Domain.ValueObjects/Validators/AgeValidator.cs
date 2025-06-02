using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects.Validators
{
    public class AgeValidator : IValidator<int>
    {
        public static int MinValue => 1;
        public static int MaxValue => 120;

        public void Validate(int value)
        {
            if (value < MinValue || value > MaxValue)
                throw new ArgumentOutOfRangeException(nameof(value),
                    ExceptionMessages.INVALID_AGE);
        }
    }
}