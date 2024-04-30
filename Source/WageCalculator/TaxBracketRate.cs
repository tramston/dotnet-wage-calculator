namespace WageCalculator;

/// <summary>
/// Represents a specific tax rate within a tax bracket, detailing the percentage rate and the type of tax rate.
/// </summary>
public class TaxBracketRate
{
    /// <summary>
    /// Gets or sets the decimal rate of tax. This value represents the percentage of income that is taxed at this rate within its bracket.
    /// </summary>
    /// <value>
    /// The tax rate as a decimal. For example, a rate of 0.25 would imply a 25% tax on income within this bracket.
    /// </value>
    public decimal Rate { get; set; } = 0.00M;

    /// <summary>
    /// Gets or sets the type of the tax rate, which can be either primary or secondary.
    /// This categorization can be used to apply different tax treatments, such as standard income tax versus alternative minimum tax.
    /// </summary>
    public TaxBracketRateType RateType { get; set; } = TaxBracketRateType.Primary;
}
