namespace Domain.ValueObjects.Exceptions
{
    internal class NonPositiveValueException(string paramName, string message)
        : ArgumentOutOfRangeException(paramName, message);
}