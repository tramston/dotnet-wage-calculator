namespace WageCalculator.Test;

using Xunit;

public class CalculateWageFromNetSalaryTests
{
    [Fact]
    public void CalculatePaycheck_Primary1000()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(877.20M, TaxBracketRateType.Primary, 5M, true, true);
        Assert.Equal(1000, calculatedSalary.Gross);
        Assert.Equal(50.00M, calculatedSalary.Contribution);
        Assert.Equal(72.80M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary1000()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(855.00M, TaxBracketRateType.Secondary);
        Assert.Equal(1000, calculatedSalary.Gross);
        Assert.Equal(50.00M, calculatedSalary.Contribution);
        Assert.Equal(95.00M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary80()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(76.00M, TaxBracketRateType.Primary);
        Assert.Equal(80, calculatedSalary.Gross);
        Assert.Equal(4.00M, calculatedSalary.Contribution);
        Assert.Equal(0, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary80()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(68.40M, TaxBracketRateType.Secondary);
        Assert.Equal(80, calculatedSalary.Gross);
        Assert.Equal(4.00M, calculatedSalary.Contribution);
        Assert.Equal(7.60M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary81()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(76.95M, TaxBracketRateType.Primary);
        Assert.Equal(81, calculatedSalary.Gross);
        Assert.Equal(4.05M, calculatedSalary.Contribution);
        Assert.Equal(0, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary81()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(69.25M, TaxBracketRateType.Secondary);
        Assert.Equal(80.99M, calculatedSalary.Gross);
        Assert.Equal(4.05M, calculatedSalary.Contribution);
        Assert.Equal(7.69M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary250()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(231.20M, TaxBracketRateType.Primary);
        Assert.Equal(250, calculatedSalary.Gross);
        Assert.Equal(12.50M, calculatedSalary.Contribution);
        Assert.Equal(6.30M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary250()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(213.75M, TaxBracketRateType.Secondary);
        Assert.Equal(250, calculatedSalary.Gross);
        Assert.Equal(12.50M, calculatedSalary.Contribution);
        Assert.Equal(23.75M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary251()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(232.11M, TaxBracketRateType.Primary);
        Assert.Equal(251, calculatedSalary.Gross);
        Assert.Equal(12.55M, calculatedSalary.Contribution);
        Assert.Equal(6.34M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary251()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(214.60M, TaxBracketRateType.Secondary);
        Assert.Equal(250.99M, calculatedSalary.Gross);
        Assert.Equal(12.55M, calculatedSalary.Contribution);
        Assert.Equal(23.84M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary450()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(406.50M, TaxBracketRateType.Primary);
        Assert.Equal(450, calculatedSalary.Gross);
        Assert.Equal(22.50M, calculatedSalary.Contribution);
        Assert.Equal(21.00M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary450()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(384.75M, TaxBracketRateType.Secondary);
        Assert.Equal(450, calculatedSalary.Gross);
        Assert.Equal(22.50M, calculatedSalary.Contribution);
        Assert.Equal(42.75M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary451()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(407.37M, TaxBracketRateType.Primary);
        Assert.Equal(451, calculatedSalary.Gross);
        Assert.Equal(22.55M, calculatedSalary.Contribution);
        Assert.Equal(21.08M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary451()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(385.60M, TaxBracketRateType.Secondary);
        Assert.Equal(450.99M, calculatedSalary.Gross);
        Assert.Equal(22.55M, calculatedSalary.Contribution);
        Assert.Equal(42.84M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary1500()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(1304.70M, TaxBracketRateType.Primary);
        Assert.Equal(1500, calculatedSalary.Gross);
        Assert.Equal(75.00M, calculatedSalary.Contribution);
        Assert.Equal(120.30M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary1500()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(1282.50M, TaxBracketRateType.Secondary);
        Assert.Equal(1500, calculatedSalary.Gross);
        Assert.Equal(75.00M, calculatedSalary.Contribution);
        Assert.Equal(142.50M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary1714_29()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromNet(1487.92M, TaxBracketRateType.Primary);
        Assert.Equal(1714.29M, calculatedSalary.Gross);
        Assert.Equal(85.71M, calculatedSalary.Contribution);
        Assert.Equal(140.66M, calculatedSalary.Tax);
    }
}
