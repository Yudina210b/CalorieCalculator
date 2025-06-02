namespace Domain.ValueObjects.Exceptions
{
    internal static class ExceptionMessages
    {
        public const string VALIDATOR_MUST_BE_SPECIFIED = "Validator must be specified for type";
        public const string VALUE_NOT_NULL_OR_WHITE_SPACE = "Value must not be null, empty or consist only of white-space characters";
        public const string NON_POSITIVE_VALUE = "Value must be positive";
        public const string VALUE_TOO_HIGH = "Value is too high";
        public const string VALUE_TOO_LOW = "Value is too low";
        public const string INVALID_AGE = "Age must be between 1 and 120 years";
        public const string INVALID_WEIGHT = "Weight must be between 1 and 300 kg";
        public const string INVALID_HEIGHT = "Height must be between 30 and 300 cm";
        public const string INVALID_QUANTITY = "Quantity must be between 1 and 10000 grams";
    }
}