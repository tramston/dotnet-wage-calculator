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
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
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
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(1332.75M, calculatedSalary.Gross);
        Assert.Equal(1133.7M, calculatedSalary.Net);
        Assert.Equal(66.64M, calculatedSalary.Contribution);
        Assert.Equal(104.41M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 1100 using the primary tax rate,
    /// but has health insurance percentage of 100%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary1100_0PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 1100,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 0.00M },
            });
        Assert.Equal(1100M, calculatedSalary.Gross);
        Assert.Equal(962.7M, calculatedSalary.Net);
        Assert.Equal(55M, calculatedSalary.Contribution);
        Assert.Equal(82.3M, calculatedSalary.Tax);
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
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 50.00M },
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
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
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
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 50.00M },
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
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 50.00M },
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
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 90.00M },
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
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 10.00M },
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
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(907.75M, calculatedSalary.Gross);
        Assert.Equal(770.33M, calculatedSalary.Net);
        Assert.Equal(45.39M, calculatedSalary.Contribution);
        Assert.Equal(64.03M, calculatedSalary.Tax);
    }

    // /// <summary>
    // /// Tests the calculation from a base gross salary of 1350 using the primary tax rate,
    // /// but has health insurance percentage of 50%
    // /// verifying correct net salary, contribution, and tax calculations.
    // /// </summary>
    // [Fact]
    // public void CalculatePaycheck_Primary1350_50PercentageHealthInsurance()
    // {
    //     var calculatedSalary = this.wageCalculator.CalculateFromGross(
    //         new WageCalculationParameters<string>
    //         {
    //             Salary = 1350 + 331.36M,
    //             TaxRateType = TaxBracketRateType.Primary,
    //             HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 50.00M },
    //         });
    //     Assert.Equal(1697.74M, calculatedSalary.Gross);
    //     Assert.Equal(1445.76M, calculatedSalary.Net);
    //     Assert.Equal(84.89M, calculatedSalary.Contribution);
    //     Assert.Equal(139.09M, calculatedSalary.Tax);
    // }

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
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 0.00M },
            });
        Assert.Equal(875.00M, calculatedSalary.Gross);
        Assert.Equal(770.32M, calculatedSalary.Net);
        Assert.Equal(43.75M, calculatedSalary.Contribution);
        Assert.Equal(60.93M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 400 using the primary tax rate,
    /// but has health insurance percentage of 0%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary400_50PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 400,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 50.00M },
            });
        Assert.Equal(416.02M, calculatedSalary.Gross);
        Assert.Equal(348.80M, calculatedSalary.Net);
        Assert.Equal(20.80M, calculatedSalary.Contribution);
        Assert.Equal(18.42M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 192.98 using the primary tax rate,
    /// but has health insurance percentage of 50%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary192_98_50PercentageHealthInsurance()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 192.98M,
                TaxRateType = TaxBracketRateType.Secondary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 50.00M },
            });
        Assert.Equal(209.36M, calculatedSalary.Gross);
        Assert.Equal(151.00M, calculatedSalary.Net);
        Assert.Equal(10.47M, calculatedSalary.Contribution);
        Assert.Equal(19.89M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 2364.22 using the primary tax rate,
    /// but has health insurance percentage of 100%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary2364_22_100PercentageHealthInsurance0Contributions()
    {
        var wageCalculatorWith32Prime =
            new WageCalculator<string>(DefaultTaxBrackets.GetList(), DefaultHealthInsuranceSchema.GetSchema(32));
        var calculatedSalary = wageCalculatorWith32Prime.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 2364.22M,
                TaxRateType = TaxBracketRateType.Primary,
                ContributionPercentage = 0,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(2399.78M, calculatedSalary.Gross);
        Assert.Equal(2150.00M, calculatedSalary.Net);
        Assert.Equal(0, calculatedSalary.Contribution);
        Assert.Equal(217.78M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 991.93 using the primary tax rate,
    /// but has health insurance percentage of 100%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary991_93_100PercentageHealthInsurance()
    {
        var wageCalculatorWith32Prime =
            new WageCalculator<string>(DefaultTaxBrackets.GetList(), DefaultHealthInsuranceSchema.GetSchema(32));
        var calculatedSalary = wageCalculatorWith32Prime.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 991.93M,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(1029.36M, calculatedSalary.Gross);
        Assert.Equal(870.30M, calculatedSalary.Net);
        Assert.Equal(51.47M, calculatedSalary.Contribution);
        Assert.Equal(75.59M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 450.38 using the primary tax rate,
    /// but has health insurance percentage of 100%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary450_38_100PercentageHealthInsurance()
    {
        var wageCalculatorWith32Prime =
            new WageCalculator<string>(DefaultTaxBrackets.GetList(), DefaultHealthInsuranceSchema.GetSchema(32));
        var calculatedSalary = wageCalculatorWith32Prime.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 450.38M,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(487.28M, calculatedSalary.Gross);
        Assert.Equal(406.83M, calculatedSalary.Net);
        Assert.Equal(24.36M, calculatedSalary.Contribution);
        Assert.Equal(24.09M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 218.39 using the primary tax rate,
    /// but has health insurance percentage of 100%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary218_39_100PercentageHealthInsurance()
    {
        var wageCalculatorWith32Prime =
            new WageCalculator<string>(DefaultTaxBrackets.GetList(), DefaultHealthInsuranceSchema.GetSchema(32));
        var calculatedSalary = wageCalculatorWith32Prime.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 218.39M,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(253.47M, calculatedSalary.Gross);
        Assert.Equal(202.37M, calculatedSalary.Net);
        Assert.Equal(12.67M, calculatedSalary.Contribution);
        Assert.Equal(6.43M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 429.69 using the primary tax rate,
    /// but has health insurance percentage of 100%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary429_69_100PercentageHealthInsurance()
    {
        var wageCalculatorWith32Prime =
            new WageCalculator<string>(DefaultTaxBrackets.GetList(), DefaultHealthInsuranceSchema.GetSchema(32));
        var calculatedSalary = wageCalculatorWith32Prime.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 429.69M,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(466.31M, calculatedSalary.Gross);
        Assert.Equal(388.75M, calculatedSalary.Net);
        Assert.Equal(23.32M, calculatedSalary.Contribution);
        Assert.Equal(22.24M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 456.69 using the primary tax rate,
    /// but has health insurance percentage of 100%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary456_59_100PercentageHealthInsurance()
    {
        var wageCalculatorWith32Prime =
            new WageCalculator<string>(DefaultTaxBrackets.GetList(), DefaultHealthInsuranceSchema.GetSchema(32));
        var calculatedSalary = wageCalculatorWith32Prime.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 456.59M,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(493.64M, calculatedSalary.Gross);
        Assert.Equal(412.26M, calculatedSalary.Net);
        Assert.Equal(24.68M, calculatedSalary.Contribution);
        Assert.Equal(24.70M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a base gross salary of 462.21 using the primary tax rate,
    /// but has health insurance percentage of 100%
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary462_21_100PercentageHealthInsurance()
    {
        var wageCalculatorWith32Prime =
            new WageCalculator<string>(DefaultTaxBrackets.GetList(), DefaultHealthInsuranceSchema.GetSchema(32));
        var calculatedSalary = wageCalculatorWith32Prime.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 462.21M,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string> { HealthInsurancePercentage = 100.00M },
            });
        Assert.Equal(499.38M, calculatedSalary.Gross);
        Assert.Equal(417.17M, calculatedSalary.Net);
        Assert.Equal(24.97M, calculatedSalary.Contribution);
        Assert.Equal(25.24M, calculatedSalary.Tax);
    }
}
