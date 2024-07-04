namespace WageCalculator;

/// <summary>
/// Represents the calculated results of a wage calculation, detailing gross and net amounts, contributions, taxes, and a breakdown of taxes by brackets.
/// </summary>
public class CalculatedWage
{
    /// <summary>
    /// Gets or sets the gross wage calculated. This is the total wage before any deductions such as taxes and contributions.
    /// </summary>
    public decimal Gross { get; set; }

    /// <summary>
    /// Gets or sets the net wage calculated. This is the wage after all deductions, including taxes and contributions, have been applied.
    /// </summary>
    public decimal Net { get; set; }

    /// <summary>
    /// Gets or sets the total contributions deducted from the gross wage. This typically includes items like pension contributions and health insurance.
    /// </summary>
    public decimal Contribution { get; set; }

    /// <summary>
    /// Gets or sets the percentage of the gross wage that is allocated for health insurance.
    /// </summary>
    /// <value>The percentage of gross wage dedicated to health insurance.</value>
    public decimal HealthInsurancePercentage { get; set; }

    /// <summary>
    /// Gets or sets the prime or base amount for health insurance before any modifications based on percentage.
    /// </summary>
    /// <value>The base prime amount for health insurance.</value>
    public decimal HealthInsurancePrime { get; set; }

    /// <summary>
    /// Gets or sets the total health insurance value.
    /// </summary>
    /// <value>The health insurance value.</value>
    public decimal HealthInsuranceValue { get; set; }

    /// <summary>
    /// Gets or sets the total tax deducted from the gross wage. This is the sum of taxes across all applicable tax brackets.
    /// </summary>
    public decimal Tax { get; set; }

    /// <summary>
    /// Gets or sets a list of <see cref="TaxBracketBreakDown"/> objects that provide a detailed breakdown of taxes applied at different income thresholds.
    /// </summary>
#pragma warning disable IDE0028
    public List<TaxBracketBreakDown> BreakDown { get; set; } = new();
#pragma warning restore IDE0028
}
