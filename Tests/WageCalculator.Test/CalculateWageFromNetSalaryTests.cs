namespace WageCalculator.Test;

using Xunit;

/// <summary>
/// Contains unit tests for the CalculateFromNet method of the WageCalculator class, testing various scenarios
/// to ensure correct calculations of gross-to-net wage conversions using different tax rates and thresholds.
/// </summary>
public class CalculateWageFromNetSalaryTests
{
    private readonly WageCalculator<string> wageCalculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculateWageFromNetSalaryTests"/> class.
    /// </summary>
    public CalculateWageFromNetSalaryTests() => this.wageCalculator =
        new WageCalculator<string>(DefaultTaxBrackets.GetList(), DefaultHealthInsuranceSchema.GetSchema());

    /// <summary>
    /// Tests the calculation from a net salary of 1000 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary1000()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 877.20M,
            TaxRateType = TaxBracketRateType.Primary,
        });
        Assert.Equal(1000, calculatedSalary.Gross);
        Assert.Equal(50.00M, calculatedSalary.Contribution);
        Assert.Equal(72.80M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 1000 using the secondary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Secondary1000()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 855.00M,
            TaxRateType = TaxBracketRateType.Secondary,
        });
        Assert.Equal(1000, calculatedSalary.Gross);
        Assert.Equal(50.00M, calculatedSalary.Contribution);
        Assert.Equal(95.00M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 80 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary80()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 76.00M,
            TaxRateType = TaxBracketRateType.Primary,
        });
        Assert.Equal(80, calculatedSalary.Gross);
        Assert.Equal(4.00M, calculatedSalary.Contribution);
        Assert.Equal(0, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 80 using the secondary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Secondary80()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 68.40M,
            TaxRateType = TaxBracketRateType.Secondary,
        });
        Assert.Equal(80, calculatedSalary.Gross);
        Assert.Equal(4.00M, calculatedSalary.Contribution);
        Assert.Equal(7.60M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 81 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary81()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 76.95M,
            TaxRateType = TaxBracketRateType.Primary,
        });
        Assert.Equal(81, calculatedSalary.Gross);
        Assert.Equal(4.05M, calculatedSalary.Contribution);
        Assert.Equal(0, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 81 using the secondary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Secondary81()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 69.25M,
            TaxRateType = TaxBracketRateType.Secondary,
        });
        Assert.Equal(80.99M, calculatedSalary.Gross);
        Assert.Equal(4.05M, calculatedSalary.Contribution);
        Assert.Equal(7.69M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 250 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary250()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 231.20M,
            TaxRateType = TaxBracketRateType.Primary,
        });
        Assert.Equal(250, calculatedSalary.Gross);
        Assert.Equal(12.50M, calculatedSalary.Contribution);
        Assert.Equal(6.30M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 250 using the secondary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Secondary250()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 213.75M,
            TaxRateType = TaxBracketRateType.Secondary,
        });
        Assert.Equal(250, calculatedSalary.Gross);
        Assert.Equal(12.50M, calculatedSalary.Contribution);
        Assert.Equal(23.75M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 251 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary251()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 232.11M,
            TaxRateType = TaxBracketRateType.Primary,
        });
        Assert.Equal(251, calculatedSalary.Gross);
        Assert.Equal(12.55M, calculatedSalary.Contribution);
        Assert.Equal(6.34M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 251 using the secondary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Secondary251()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 214.60M,
            TaxRateType = TaxBracketRateType.Secondary,
        });
        Assert.Equal(250.99M, calculatedSalary.Gross);
        Assert.Equal(12.55M, calculatedSalary.Contribution);
        Assert.Equal(23.84M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 450 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary450()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 406.50M,
            TaxRateType = TaxBracketRateType.Primary,
        });
        Assert.Equal(450, calculatedSalary.Gross);
        Assert.Equal(22.50M, calculatedSalary.Contribution);
        Assert.Equal(21.00M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 450 using the secondary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Secondary450()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 384.75M,
            TaxRateType = TaxBracketRateType.Secondary,
        });
        Assert.Equal(450, calculatedSalary.Gross);
        Assert.Equal(22.50M, calculatedSalary.Contribution);
        Assert.Equal(42.75M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 451 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary451()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 407.37M,
            TaxRateType = TaxBracketRateType.Primary,
        });
        Assert.Equal(451, calculatedSalary.Gross);
        Assert.Equal(22.55M, calculatedSalary.Contribution);
        Assert.Equal(21.08M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 451 using the secondary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Secondary451()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 385.60M,
            TaxRateType = TaxBracketRateType.Secondary,
        });
        Assert.Equal(450.99M, calculatedSalary.Gross);
        Assert.Equal(22.55M, calculatedSalary.Contribution);
        Assert.Equal(42.84M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 1500 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary1500()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 1304.70M,
            TaxRateType = TaxBracketRateType.Primary,
        });
        Assert.Equal(1500, calculatedSalary.Gross);
        Assert.Equal(75.00M, calculatedSalary.Contribution);
        Assert.Equal(120.30M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 1500 using the secondary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Secondary1500()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 1282.50M,
            TaxRateType = TaxBracketRateType.Secondary,
        });
        Assert.Equal(1500, calculatedSalary.Gross);
        Assert.Equal(75.00M, calculatedSalary.Contribution);
        Assert.Equal(142.50M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a net salary of 1714.29 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary1714_29()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromNet(new WageCalculationParameters<string>
        {
            Salary = 1487.92M,
            TaxRateType = TaxBracketRateType.Primary,
        });
        Assert.Equal(1714.29M, calculatedSalary.Gross);
        Assert.Equal(85.71M, calculatedSalary.Contribution);
        Assert.Equal(140.66M, calculatedSalary.Tax);
    }
}
