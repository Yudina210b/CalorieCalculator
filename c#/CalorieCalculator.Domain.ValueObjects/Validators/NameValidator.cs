using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects.Validators
{
    public class NameValidator : IValidator<string>
    {
        public static int MinLength => 2;
        public static int MaxLength => 100;

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(nameof(value),
                    ExceptionMessages.VALUE_NOT_NULL_OR_WHITE_SPACE);

            if (value.Length < MinLength)
                throw new TooLowValueException(nameof(value), value.Length, MinLength);

            if (value.Length > MaxLength)
                throw new TooHighValueException(nameof(value), value.Length, MaxLength);
        }
    }
}