namespace WageCalculator.Test;

using Xunit;

/// <summary>
/// Contains unit tests for the CalculateFromGross method of the WageCalculator class, testing various scenarios
/// to ensure correct calculations of gross-to-net wage conversions using different tax rates and thresholds.
/// </summary>
public class CalculateWageWithHealthInsuranceTests
{
    private readonly WageCalculator<string> wageCalculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculateWageWithHealthInsuranceTests"/> class.
    /// </summary>
    public CalculateWageWithHealthInsuranceTests() => this.wageCalculator =
        new WageCalculator<string>(DefaultTaxBrackets.GetList(), DefaultHealthInsuranceSchema.GetSchema());

    /// <summary>
    /// Tests the calculation from a gross salary of 1000 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary1000_100PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 1000,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M, HasHealthInsurance = true },
            });
        Assert.Equal(1032.75M, calculatedSalary.Gross);
        Assert.Equal(877.20M, calculatedSalary.Net);
        Assert.Equal(51.64M, calculatedSalary.Contribution);
        Assert.Equal(75.91M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 1300 using the primary tax rate,
    /// but has health insurance percentage of 100%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary1300_100PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 1300,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M, HasHealthInsurance = true },
            });
        Assert.Equal(1332.75M, calculatedSalary.Gross);
        Assert.Equal(1133.7M, calculatedSalary.Net);
        Assert.Equal(66.64M, calculatedSalary.Contribution);
        Assert.Equal(104.41M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 970 using the primary tax rate,
    /// but has health insurance percentage of 50%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary970_50PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 970,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 50.00M, HasHealthInsurance = true },
            });
        Assert.Equal(986.38M, calculatedSalary.Gross);
        Assert.Equal(837.55M, calculatedSalary.Net);
        Assert.Equal(49.32M, calculatedSalary.Contribution);
        Assert.Equal(71.51M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 975 using the primary tax rate,
    /// but has health insurance percentage of 100%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary975_100PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 975,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M, HasHealthInsurance = true },
            });
        Assert.Equal(1007.75M, calculatedSalary.Gross);
        Assert.Equal(855.83M, calculatedSalary.Net);
        Assert.Equal(50.39M, calculatedSalary.Contribution);
        Assert.Equal(73.53M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 875 using the primary tax rate,
    /// but has health insurance percentage of 50%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary875_50PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 875,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 50.00M, HasHealthInsurance = true },
            });
        Assert.Equal(891.38M, calculatedSalary.Gross);
        Assert.Equal(756.33M, calculatedSalary.Net);
        Assert.Equal(44.57M, calculatedSalary.Contribution);
        Assert.Equal(62.48M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 875 using the primary tax rate,
    /// but has health insurance percentage of 50%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary910_50PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 910,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 50.00M, HasHealthInsurance = true },
            });
        Assert.Equal(926.38M, calculatedSalary.Gross);
        Assert.Equal(786.25M, calculatedSalary.Net);
        Assert.Equal(46.32M, calculatedSalary.Contribution);
        Assert.Equal(65.81M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 875 using the primary tax rate,
    /// but has health insurance percentage of 90%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary875_90PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 875,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 90.00M, HasHealthInsurance = true },
            });
        Assert.Equal(904.47M, calculatedSalary.Gross);
        Assert.Equal(767.53M, calculatedSalary.Net);
        Assert.Equal(45.22M, calculatedSalary.Contribution);
        Assert.Equal(63.72M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 875 using the primary tax rate,
    /// but has health insurance percentage of 10%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary875_10PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 875,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 10.00M, HasHealthInsurance = true },
            });
        Assert.Equal(878.27M, calculatedSalary.Gross);
        Assert.Equal(745.13M, calculatedSalary.Net);
        Assert.Equal(43.91M, calculatedSalary.Contribution);
        Assert.Equal(61.23M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 875 using the primary tax rate,
    /// but has health insurance percentage of 100%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary875_100PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 875,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M, HasHealthInsurance = true, },
            });
        Assert.Equal(907.75M, calculatedSalary.Gross);
        Assert.Equal(770.33M, calculatedSalary.Net);
        Assert.Equal(45.39M, calculatedSalary.Contribution);
        Assert.Equal(64.03M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 1350 using the primary tax rate,
    /// but has health insurance percentage of 50%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary1350_50PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 1350 + 331.36M,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 50.00M, HasHealthInsurance = true },
            });
        Assert.Equal(1697.74M, calculatedSalary.Gross);
        Assert.Equal(1445.76M, calculatedSalary.Net);
        Assert.Equal(84.89M, calculatedSalary.Contribution);
        Assert.Equal(139.09M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 875 using the primary tax rate,
    /// but has health insurance percentage of 0%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary875_0PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 875,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 0.00M, HasHealthInsurance = true },
            });
        Assert.Equal(875.00M, calculatedSalary.Gross);
        Assert.Equal(742.33M, calculatedSalary.Net);
        Assert.Equal(43.75M, calculatedSalary.Contribution);
        Assert.Equal(60.92M, calculatedSalary.Tax);
    }
}
