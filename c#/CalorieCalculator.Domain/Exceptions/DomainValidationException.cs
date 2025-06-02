using Common.Enums;

namespace Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public CalculationStatus StatusCode { get; } // Зависимость от Common

        public DomainValidationException(string message, CalculationStatus status)
            : base(message)
        {
            StatusCode = status;
        }
    }
}