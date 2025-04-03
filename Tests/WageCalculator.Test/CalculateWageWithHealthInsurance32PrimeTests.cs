namespace WageCalculator.Test;

using Xunit;

/// <summary>
/// Contains unit tests for the CalculateFromGross method of the WageCalculator class, testing various scenarios
/// to ensure correct calculations of gross-to-net wage conversions using different tax rates and thresholds.
/// </summary>
public class CalculateWageWithHealthInsurance32PrimeTests
{
    private readonly WageCalculator<string> wageCalculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculateWageWithHealthInsurance32PrimeTests"/> class.
    /// </summary>
    public CalculateWageWithHealthInsurance32PrimeTests() => this.wageCalculator =
        new WageCalculator<string>(DefaultTaxBrackets.GetNewList(), DefaultHealthInsuranceSchema.GetSchema(32));

    /// <summary>
    /// Tests the calculation from a gross salary of 1000 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary843_27_100PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 843.27M,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(880.7M, calculatedSalary.Gross);
        Assert.Equal(750M, calculatedSalary.Net);
        Assert.Equal(44.04M, calculatedSalary.Contribution);
        Assert.Equal(54.67M, calculatedSalary.Tax);
        Assert.Equal(37.43M, calculatedSalary.HealthInsuranceValue);
    }
}
