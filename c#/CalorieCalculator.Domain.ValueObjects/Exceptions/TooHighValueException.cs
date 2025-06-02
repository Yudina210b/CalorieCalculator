namespace Domain.ValueObjects.Exceptions
{
    internal class TooHighValueException(string paramName, decimal value, decimal maxValue)
        : ArgumentOutOfRangeException(paramName,
            $"Value {value} is greater than maximum allowed value {maxValue}");
}