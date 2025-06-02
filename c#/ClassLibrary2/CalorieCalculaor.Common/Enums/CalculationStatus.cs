namespace Common.Enums
{
    public enum CalculationStatus
    {
        Success,
        FaultedInvalidInput,
        FaultedUserNotFound,
        FaultedProductNotFound,
        FaultedMealNotFound,
        FaultedNegativeValue,
        FaultedCalculationError,
        FaultedDatabaseError
    }
}