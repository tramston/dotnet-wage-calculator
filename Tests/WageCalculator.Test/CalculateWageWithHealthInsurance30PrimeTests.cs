namespace WageCalculator.Test;

using Xunit;

/// <summary>
/// Contains unit tests for the CalculateFromGross method of the WageCalculator class, testing various scenarios
/// to ensure correct calculations of gross-to-net wage conversions using different tax rates and thresholds.
/// </summary>
public class CalculateWageWithHealthInsurance30PrimeTests
{
    private readonly WageCalculator<string> wageCalculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculateWageWithHealthInsurance30PrimeTests"/> class.
    /// </summary>
    public CalculateWageWithHealthInsurance30PrimeTests() => this.wageCalculator =
        new WageCalculator<string>(DefaultTaxBrackets.GetNewList(), DefaultHealthInsuranceSchema.GetSchema(30));

    /// <summary>
    /// Tests the calculation from a gross salary of 1000 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary850_100PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 850,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(885.09M, calculatedSalary.Gross);
        Assert.Equal(755.75M, calculatedSalary.Net);
        Assert.Equal(44.25M, calculatedSalary.Contribution);
        Assert.Equal(55.08M, calculatedSalary.Tax);
        Assert.Equal(35.09M, calculatedSalary.HealthInsuranceValue);
    }

    /// <summary>
    /// Tests the calculation from a gross salary of 1000 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary250_100PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 250,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(283.18M, calculatedSalary.Gross);
        Assert.Equal(237.50M, calculatedSalary.Net);
        Assert.Equal(14.16M, calculatedSalary.Contribution);
        Assert.Equal(1.52M, calculatedSalary.Tax);
        Assert.Equal(33.18M, calculatedSalary.HealthInsuranceValue);
    }
}
