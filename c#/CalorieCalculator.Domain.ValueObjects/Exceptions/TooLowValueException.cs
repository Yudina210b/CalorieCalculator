namespace Domain.ValueObjects.Exceptions
{
    internal class TooLowValueException(string paramName, decimal value, decimal minValue)
        : ArgumentOutOfRangeException(paramName,
            $"Value {value} is less than minimum allowed value {minValue}");
}