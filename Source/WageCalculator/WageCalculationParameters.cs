namespace WageCalculator;

/// <summary>
/// Encapsulates the parameters needed for calculating wages.
/// </summary>
/// <typeparam name="T">The type of the identifier used in the health insurance setup.</typeparam>
public class WageCalculationParameters<T>
{
    /// <summary>
    /// Gets or sets the salary amount on which the calculation is based.
    /// </summary>
    /// <value>The salary amount used as the base for wage calculations.</value>
    public decimal Salary { get; set; }

    /// <summary>
    /// Gets or sets the type of tax rate to apply during the calculation.
    /// </summary>
    /// <value>The tax rate type (primary or secondary) used to determine the tax calculations.</value>
    public TaxBracketRateType TaxRateType { get; set; }

    /// <summary>
    /// Gets or sets the percentage of contributions deducted from the salary.
    /// </summary>
    /// <value>The contribution rate, specified as a percentage. Defaults to 5.0%.</value>
    public decimal ContributionPercentage { get; set; } = 5.0M;

    /// <summary>
    /// Gets or sets the health insurance setup, detailing the coverage and members included in health insurance calculations.
    /// </summary>
    /// <value>The health insurance setup, detailing coverage percentages and member details using the generic type T for identifiers.</value>
    public HealthInsuranceSetup<T> HealthInsuranceSetup { get; set; } = new HealthInsuranceSetup<T>();

    /// <summary>
    /// Gets or sets a value indicating whether tax deductions should be considered in the calculation.
    /// </summary>
    /// <value>True if taxes are to be deducted; otherwise, false.</value>
    public bool HasTaxes { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether a detailed breakdown of taxes at each tax bracket is required.
    /// </summary>
    /// <value>True if a tax breakdown is required; otherwise, false.</value>
    public bool TaxBreakdown { get; set; }
}
