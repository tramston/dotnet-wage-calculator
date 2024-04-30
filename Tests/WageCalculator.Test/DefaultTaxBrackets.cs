namespace WageCalculator.Test;

/// <summary>
/// Provides a collection of predefined tax brackets for testing or initialization purposes.
/// </summary>
public static class DefaultTaxBrackets
{
    /// <summary>
    /// Retrieves a list of default tax brackets. This method is typically used to provide a consistent set of tax brackets for testing the WageCalculator library.
    /// Each bracket includes a mix of primary and secondary tax rates, applicable up to specified income thresholds.
    /// </summary>
    /// <returns>
    /// A List of <see cref="TaxBracket"/> objects, each configured with specific thresholds and associated tax rates.
    /// </returns>
    /// <example>
    /// Here is how you might use the GetList method to initialize a wage calculator:
    /// <code>
    /// var taxBrackets = DefaultTaxBrackets.GetList();
    /// var wageCalculator = new WageCalculator(taxBrackets);
    /// </code>
    /// </example>
    public static List<TaxBracket> GetList() => new()
    {
        new()
        {
            Threshold = 80,
            Rates =
                new()
                {
                    new() { Rate = 0, RateType = TaxBracketRateType.Primary, },
                    new() { Rate = 0.1M, RateType = TaxBracketRateType.Secondary, },
                },
        },
        new()
        {
            Threshold = 250,
            Rates =
                new()
                {
                    new() { Rate = 0.04M, RateType = TaxBracketRateType.Primary, },
                    new() { Rate = 0.1M, RateType = TaxBracketRateType.Secondary, },
                },
        },
        new()
        {
            Threshold = 450,
            Rates = new()
            {
                new() { Rate = 0.08M, RateType = TaxBracketRateType.Primary, },
                new() { Rate = 0.1M, RateType = TaxBracketRateType.Secondary, },
            },
        },
        new()
        {
            Rates = new()
            {
                new() { Rate = 0.1M, RateType = TaxBracketRateType.Primary, },
                new() { Rate = 0.1M, RateType = TaxBracketRateType.Secondary, },
            },
        },
    };
}
